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

        private void button1_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var videoId = textBox1.Text;
            var ytb = new List<VideoModel>();
            ytb.Add(YouTubeApi.GetVideInfoById(videoId));

            stopWatch.Stop();
            dgw.DataSource = ytb.ToList();
            labelCount.Text = ytb.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
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

            var videoId = textBox1.Text;
            var comments = YouTubeApi.GetCommentsByVideoId(videoId);
            stopWatch.Stop();
            dgw.DataSource = comments.ToList();

            labelCount.Text = comments.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }
    }
}
