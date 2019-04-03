using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YoutubeSearch;

namespace YoutubeListDownloader
{
    public partial class Dashboard : Form
    {
        string DownloadPath;
        int totalTasks;
        List<Thread> threads;
        Stopwatch stop;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "TextFiles (*.txt)|*.txt";
            open.ShowDialog();
            var lines = File.ReadAllLines(open.FileName);
            foreach (var item in lines)
            {
                listBoxVideos.Items.Add(item);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listBoxVideos.Items.Clear();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            listBoxVideos.Items.Add(textBoxAdd.Text);
            textBoxAdd.Text = string.Empty;
        }

        private void TextBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxVideos.Items.Add(textBoxAdd.Text);
                textBoxAdd.Text = string.Empty;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (!GetDownloadPath()) return;

            buttonStart.Enabled = false;
            buttonCancel.Enabled = true;

            stop = Stopwatch.StartNew();

            checkBoxConvert.Enabled = false;
            checkBoxDelete.Enabled = false;
            int vidCount = listBoxVideos.Items.Count;
            totalTasks = vidCount * (checkBoxConvert.Checked ? (checkBoxDelete.Checked ? 3 : 2) : 1);
            progressBarDownloads.Maximum = totalTasks;
            progressBarDownloads.Step = 1;
            progressBarDownloads.Minimum = 0;
            progressBarDownloads.Value = 0;

            threads = new List<Thread>();
            foreach (string entry in listBoxVideos.Items.OfType<string>().ToArray())
            {
                Thread newThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    ProcessEntry(entry);
                });
                threads.Add(newThread);
                newThread.Start();
            };
        }

        private async Task ProcessEntry(string entry)
        {
            // Check if it is a valid URI
            Uri uriResult;
            bool result = Uri.TryCreate(entry, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                string searchResult = SearchVideo(entry);
                SaveVideoToDisk(searchResult, checkBoxConvert.Checked, checkBoxDelete.Checked);
            }
            else
            {
                SaveVideoToDisk(entry.ToString(), checkBoxConvert.Checked, checkBoxDelete.Checked);
            }
        }

        private bool GetDownloadPath()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = Environment.CurrentDirectory;
            folder.ShowNewFolderButton = true;
            folder.Description = "Select download path";
            var result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                DownloadPath = folder.SelectedPath + @"\";
                Log($"Starting to download to {DownloadPath}");
                return true;
            }
            return false;
        }

        private string SearchVideo(string search)
        {
            VideoSearch items = new VideoSearch();
            List<Video> list = new List<Video>();
            VideoInformation firstVideo = items.SearchQuery(search, 1).FirstOrDefault();

            return firstVideo.Url;
        }

        private void SaveVideoToDisk(string link, bool convert, bool delete)
        {
            // Download Video
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(link); // gets a Video object with info about the video
            Log($"Downloading {video.FullName}");
            File.WriteAllBytes(DownloadPath + video.FullName, video.GetBytes());
            AddProgress();

            if (convert)
            {
                // Convert Video
                Log($"Converting {video.FullName}");
                var inputFile = new MediaFile { Filename = DownloadPath + video.FullName };
                var outputFile = new MediaFile { Filename = $"{DownloadPath + video.FullName}.mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    engine.Convert(inputFile, outputFile);
                }
                AddProgress();

                if (delete)
                {
                    Log($"Deleting video file {video.FullName}");
                    File.Delete(DownloadPath + video.FullName);
                    AddProgress();
                }
            }

        }

        private delegate void SafeCallProgressBar();
        private void AddProgress()
        {
            if (progressBarDownloads.InvokeRequired)
            {
                var d = new SafeCallProgressBar(AddProgress);
                Invoke(d, new object[] { });
            }
            else
            {
                progressBarDownloads.PerformStep();
                progressBarDownloads.Update();

                if (progressBarDownloads.Value == totalTasks)
                {
                    stop.Stop();
                    Log($"Done! ~ {stop.Elapsed.TotalMinutes} Minutes");

                    buttonStart.Enabled = true;
                    buttonCancel.Enabled = false;
                    checkBoxConvert.Enabled = true;
                    checkBoxDelete.Enabled = true;
                    MessageBox.Show($"Done! ~ {stop.Elapsed.TotalMinutes} Minutes");
                }
            }
        }

        private delegate void SafeCallDelegate(string text);

        private void Log(string text)
        {
            if (listBoxLog.InvokeRequired)
            {
                var d = new SafeCallDelegate(Log);
                Invoke(d, new object[] { text });
            }
            else
            {
                string time = DateTime.Now.ToString("HH:mm");
                listBoxLog.Items.Add(time + " " + text);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
        }

        private void CheckBoxConvert_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxDelete.Enabled = (sender as CheckBox).Checked;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = false;

            Log("ABORTING...");
            foreach (var thread in threads)
            {
                thread.Abort();
            }
            progressBarDownloads.Value = 0;
            progressBarDownloads.Update();
            stop.Stop();
            Log($"Stopped! ~ {stop.Elapsed.TotalMinutes} Minutes");
            buttonStart.Enabled = true;
        }
    }
}
