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

namespace ReviewFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string filePath;
        public string fileContent;
        private void 保存到文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog=new SaveFileDialog())
            {
                saveFileDialog.Filter= "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog()==DialogResult.OK)
                {
                    //using (StreamWriter sw=new StreamWriter(saveFileDialog.FileName,false,Encoding.Default,1024))
                    //{
                    //    sw.Write(richTextBox1.Text);
                    //    sw.Flush();
                    //}
                    //
                    using (FileStream fs = new FileStream(saveFileDialog.FileName,FileMode.OpenOrCreate))
                    {
                        string temp = richTextBox1.Text;
                        byte[] data = Encoding.UTF8.GetBytes(temp);
                        fs.Write(data, 0, data.Length);
                    }
                }
            }
        }

        private void 载入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog=new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    //读取文件到流
                    Stream stream= openFileDialog.OpenFile();
                    using (StreamReader reader=new StreamReader(stream,Encoding.UTF8))
                    {
                        fileContent = reader.ReadToEnd();
                        
                    }
                    richTextBox1.Text = fileContent;
                }
            }
        }
    }
}
