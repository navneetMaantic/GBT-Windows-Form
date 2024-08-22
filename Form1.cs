using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string path;
        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string path = "D:\\GBT";
            Process process = new Process();
            process.EnableRaisingEvents = false;
            //process.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\Java\jre1.8.0_301\bin";
            Console.WriteLine(path);
            process.StartInfo.WorkingDirectory = path;        
            process.StartInfo.FileName = "java.exe";
            process.StartInfo.Arguments = "-jar " + path + "\\gbtr.jar " + getRuleName(); // "\\testng.xml";
            process.Start();
            comboBox1.Enabled = false;
            button1.Enabled = false;
        }
        public String getRuleName()
        {
            string output="";
            if(comboBox1.SelectedIndex == 0)
            {
                output = "testng_decsTable.xml";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                output= "testng_activity.xml";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                output = "testng_sla.xml";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                output = "testng.xml";
            }
            Console.WriteLine(output);
            return output;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            button1.Visible = false;
            comboBox1.Enabled = true;
            button1.Enabled = true;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog.SelectedPath;
                    lblFolderLocation.Text = path;
                }
            }
            Console.WriteLine(path);
        }
    }
}
