using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using derinYouTube.Extensions;

namespace derinYouTube
{
    public partial class FrmMain : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dgw.DoubleBuffered(true);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var listId = textBox2.Text;
            var ytb = YouTubeApi.GetPlayListById(listId);
            stopWatch.Stop();
            dgw.DataSource = ytb.ToList();
            labelCount.Text = ytb.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var videoId = textBoxVideoId.Text;
            var comments = YouTubeApi.GetCommentsByVideoId(videoId);
            stopWatch.Stop();
            dgw.DataSource = comments.ToList();

            labelCount.Text = comments.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var videoId = textBoxVideoId.Text;
            var comments = YouTubeApi.GetLiveCommentsByVideoId(videoId);
            stopWatch.Stop();
            dgw.DataSource = comments.ToList();

            labelCount.Text = comments.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle(bool tumu = true)
        {
            
            richTextBoxDescription.Text = string.Empty;
            richTextBoxTitle.Text = string.Empty;
            linkLabelChannelId.Text = "Channel ID";
            dtPublishDate.Value = DateTime.Today;
            labelTime.Text = "0";
            if (tumu)
            {
                textBoxVideoId.Text = string.Empty;
                textBoxVideoId.Focus();
            }
        }

        private void buttonGetVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxVideoId.Text))
            {
                MessageBox.Show("Bilgileri okunacak videnonun ID'si girilmeli", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxVideoId.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var video = YouTubeApi.GetVideInfoById(textBoxVideoId.Text);
            if (video == null)
            {
                Temizle(false);
            }
            else
            {
                richTextBoxTitle.Text = video.Title;
                richTextBoxDescription.Text = video.Description;
                linkLabelChannelId.Text = video.ChannelId;
                dtPublishDate.Value = video.PublishedDate.Value;
            }

            Cursor = Cursors.Default;
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void linkLabelChannelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Kanala gidelim
        }
    }
}
