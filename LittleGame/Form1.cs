using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleGame
{
    public partial class Form1 : Form
    {
        Status status = new Status();
        private bool Start;
        private enum MyDifficultEnum
        {
            难度1, 难度2, 难度3, 难度4, 难度5, 难度6, 难度7,

        }
        enum MyEnum
        {
            ss
        }
        public Form1()
        {
            InitializeComponent();
        }
        private Random random;
        private MyDifficultEnum difficultEnum;
        private void Form1_Load(object sender, EventArgs e)
        {
            FormChooseDiffculty formChoose = new FormChooseDiffculty();
            if (formChoose.ShowDialog()!=DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                difficultEnum = (MyDifficultEnum)int.Parse(FormChooseDiffculty.choosedifficulty);
                Start = true;
                random = new Random();
                timer1.Interval = 800;
                timer1.Start();
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Start)
            {
                listBox1.Items.Add("Gamestart");                
                Start = false;
                return;
            }
            if (listBox1.Items.Contains("Gamestart"))
            {
                listBox1.Items.Clear();
            }
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count>7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("GameOver");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                int winInterval = 100;
                switch (difficultEnum)
                {
                    case MyDifficultEnum.难度1:
                        winInterval = 500;
                        break;
                    case MyDifficultEnum.难度2:
                        winInterval = 400;
                        break;
                    case MyDifficultEnum.难度3:
                        winInterval = 350;
                        break;
                    case MyDifficultEnum.难度4:
                        winInterval = 250;
                        break;
                    case MyDifficultEnum.难度5:
                        winInterval = 220;
                        break;
                    case MyDifficultEnum.难度6:
                        winInterval = 210;
                        break;
                    case MyDifficultEnum.难度7:
                        winInterval = 200;
                        break;
                    default:
                        break;
                }
                if (timer1.Interval > 410)
                {
                    timer1.Interval -= 10;
                }
                else if (timer1.Interval > winInterval)
                {
                    timer1.Interval -= 7;
                }
                else if (timer1.Interval< winInterval)
                {
                    timer1.Stop();
                    listBox1.Items.Clear();
                    listBox1.Items.Add("You Win!");
                }
                difficultyProcessBar.Value = 800 - timer1.Interval;
                status.Update(true);
            }
            else
            {
                status.Update(false);
            }
            ShowScore(status);
        }

        private void ShowScore(Status stat)
        {
            status = stat;
            toolStripStatusLabel1.Text = "Correct:" + stat.correct.ToString();
            toolStripStatusLabel2.Text = "Missed:" + stat.missed.ToString();
            toolStripStatusLabel3.Text = "Total:" + stat.total.ToString();
            toolStripStatusLabel4.Text = "Accuracy:" + stat.accuracy.ToString() + "%";
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //当点击控件而且控件显示GameOver,重新开始游戏
            if (listBox1.Items.Contains("GameOver"))
            {
                ShowScore(new Status());
                Start = true;
                timer1.Interval = 800;
                timer1.Start();
            }
        }
    }
    public class Status
    {
        public int total;
        public int missed;
        public int correct;
        public int accuracy;
        public void Update(bool correctKey)
        {
            total++;
            if (correctKey)
            {
                correct++;
            }
            else
            {
                missed++;
            }
            accuracy = 100 * correct / total;
        }
    }
    
}
