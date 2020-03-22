using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace TestingRadom
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.ProgressPercentage.ToString();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i<100)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //开启随机抽奖
            //当点击开始后，开启一个线程显示1-500随机数
            if (thread != null)
            {
                thread.Abort();
                thread = null;
                button1.Text = "开始随机抽奖";
                return;
            }
            thread = new Thread(Lottery);
            thread.Start();
            button1.Text = "Stop!";
        }

        private void Lottery()
        {
            while (true)
            {
                if (label1.InvokeRequired)
                {
                    this.Invoke(new Action(() => { label1.Text = "No." + random.Next(0, 500).ToString(); }));
                }
                else
                {
                    label1.Text = "No." + random.Next(0, 500).ToString();
                }
                Thread.Sleep(10);
            }
        }
    }
}
