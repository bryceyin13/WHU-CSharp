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

namespace hw4.e3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "请选择要打开的文件";
            ofd.Multiselect = true;
            ofd.Filter = "文本文件|*.txt|图片文件|*.jpg|所有文件|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = ofd.SafeFileName;
                FileStream fsin = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader brin = new StreamReader(fsin, Encoding.UTF8);
                label5.Text = brin.ReadToEnd();
                brin.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "请选择要打开的文件";
            ofd.Multiselect = true;
            ofd.Filter = "文本文件|*.txt|图片文件|*.jpg|所有文件|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string fileName = ofd.SafeFileName;
                FileStream fsin = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader brin = new StreamReader(fsin, Encoding.UTF8);
                label6.Text = brin.ReadToEnd();
                brin.Close();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filename = @".\Data\";
            Directory.CreateDirectory(filename);
            FileStream fs = new FileStream(@".\Data\" + textBox2.Text + ".txt", FileMode.OpenOrCreate);
            StreamWriter StrWt = new StreamWriter(fs, Encoding.UTF8);
            StrWt.WriteLine(label5.Text);
            StrWt.WriteLine(label6.Text);
            StrWt.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
