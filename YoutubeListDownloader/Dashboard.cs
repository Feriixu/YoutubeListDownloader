using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

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
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.Description = "Select download path";
            folder.ShowDialog();
            DownloadPath = folder.SelectedPath;
            MessageBox.Show("Videos will be saved to " + DownloadPath);
            foreach (var video in listBoxVideos.Items)
            {
                SaveVideoToDisk(video.ToString());
            }
        }

        private void SaveVideoToDisk(string link)
        {
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(link); // gets a Video object with info about the video
            File.WriteAllBytes(DownloadPath + @"\" + video.FullName, video.GetBytes());
        }
    }
}
