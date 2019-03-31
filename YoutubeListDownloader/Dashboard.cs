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
            Stopwatch watch = Stopwatch.StartNew(); // Start a stopwatch

            GetDownloadPath();

            var tasks = new List<Task>();
            //Parallel.ForEach<string>(listBoxVideos.Items.OfType<string>().ToArray(), new ParallelOptions { MaxDegreeOfParallelism = trackBarParallelTasks.Value },
            //entry =>
            //{
            //    tasks.Add(ProcessEntry(entry));
            //});

            foreach (string entry in listBoxVideos.Items.OfType<string>().ToArray())
            {
                tasks.Add(ProcessEntry(entry));
            };

            Task.WaitAll(tasks.ToArray());

            watch.Stop();
            Log($"DONE! ~ {watch.ElapsedMilliseconds / 1000} seconds");
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

        private void GetDownloadPath()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.Description = "Select download path";
            folder.ShowDialog();
            DownloadPath = folder.SelectedPath + @"\";
            Log($"Starting to download to {DownloadPath}");
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

                if (delete)
                {
                    Log($"Deleting video file {video.FullName}");
                    File.Delete(DownloadPath + video.FullName);
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
                listBoxLog.Items.Add(text);
            }
        }

        private void TrackBarParallelTasks_ValueChanged(object sender, EventArgs e)
        {
            labelParallelTasks.Text = trackBarParallelTasks.Value.ToString();
        }


    }
}
