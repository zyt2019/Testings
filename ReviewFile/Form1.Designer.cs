﻿namespace ReviewFile
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.载入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(917, 219);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入文件ToolStripMenuItem,
            this.保存到文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 载入文件ToolStripMenuItem
            // 
            this.载入文件ToolStripMenuItem.Name = "载入文件ToolStripMenuItem";
            this.载入文件ToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.载入文件ToolStripMenuItem.Text = "载入文件&A";
            this.载入文件ToolStripMenuItem.Click += new System.EventHandler(this.载入文件ToolStripMenuItem_Click);
            // 
            // 保存到文件ToolStripMenuItem
            // 
            this.保存到文件ToolStripMenuItem.Name = "保存到文件ToolStripMenuItem";
            this.保存到文件ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.保存到文件ToolStripMenuItem.Text = "保存到文件&B";
            this.保存到文件ToolStripMenuItem.Click += new System.EventHandler(this.保存到文件ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 373);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 载入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存到文件ToolStripMenuItem;
    }
}

