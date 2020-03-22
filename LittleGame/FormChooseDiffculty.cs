using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleGame
{
    public partial class FormChooseDiffculty : Form
    {
        public static string choosedifficulty;
        private Difficulty Mydifficulty;
        public FormChooseDiffculty()
        {
            InitializeComponent();
            Mydifficulty = new Difficulty();
            listBox1.DataSource = Mydifficulty.Diff;
        }

        private void FormChooseDiffculty_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mydifficulty!=null)
            {
                choosedifficulty=(sender as ListBox).SelectedItem.ToString();
            }
        }
    }
    public class Difficulty
    {
        /// <summary>
        /// 难度
        /// </summary>
        public List<int> Diff = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

    }
}
