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

namespace optxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string path = @"\\\\192.168.0.246\\202共享\\重要,勿删!";

            try
            {
                if (File.Exists(path))
                {
                    InitializeComponent();

                }
                else
                {
                    MessageBox.Show("只允许希而科内部公司使用!请关闭");


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("只允许希而科内部公司使用!");
                MessageBox.Show(ex.Message);

            }
           // InitializeComponent();
        }
        public int lineIndex(string path)
        {
            int Length = 0;
            StreamReader FileStreamTemp = new StreamReader(path);
            while ((FileStreamTemp.ReadLine()) != null)
            {
                Length++;
            }
            FileStreamTemp.Close();
            return Length;
        }

        private void ReadTXTLineByLine(string path, int counter, string tpath,int hs)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            //    StreamReader sr = new StreamReader(path, Encoding.UTF8);
            //   System.IO.StreamReader file = new System.IO.StreamReader(path);//创建文件流，path为文本文件路径  
            int count = 0;
            string line = "";
            string output = "";
            while ((line = sr.ReadLine()) != null)
            {



                // int lineLength = lineIndex(path);
                if (count >= hs * counter + 0 && count <= hs * counter + hs)
                {

                    output = line;


                    FileStream fs = new FileStream(tpath, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    sw.WriteLine(output);
                    sw.Close();
                    fs.Close();



                }
                count++;

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = this.openFileDialog2.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int hs = Convert.ToInt32(textBox3.Text);
            int li = lineIndex(this.textBox1.Text);
            //  MessageBox.Show(ss.ToString());Math.Ceiling(Convert.ToDecimal( li/200))
            for (int i = 0; i <= Math.Ceiling(Convert.ToDecimal(li / hs)); i++)

            {
                int j = i + 1;
                // MessageBox.Show(System.IO.Path.GetFileName(openFileDialog2.FileName));
                string tempath = System.IO.Path.GetFileName(openFileDialog1.FileName);
                string filename1 = tempath.Substring(0, tempath.Length - 4);
                System.IO.File.Copy(this.textBox2.Text, System.IO.Path.GetDirectoryName(openFileDialog2.FileName) + "\\" + filename1 + j + ".txt", true);//复制模板文件
                ReadTXTLineByLine(this.textBox1.Text, i, System.IO.Path.GetDirectoryName(openFileDialog2.FileName) + "\\" + filename1 + j + ".txt",hs);
                // MessageBox.Show("完成"+i);

            }
            MessageBox.Show("完成");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
