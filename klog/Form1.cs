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

namespace klog
{
    public partial class Form1 : Form
    {
        //Point WindowPosition;
        private Point mouseOffset;
        private bool isMouseDown = false;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Текстовые файлы(*.txt)|*.txt|Все форматы(*.*)|*.*";
            label1.Text = this.Text;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {   
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
                textBox1.Text = Program.BoxString;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {if(textBox1.Text != "")
                {
                    try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                    streamWriter.WriteLine(textBox1.Text);
                    streamWriter.Close();
                }
                    catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = Program.BoxString;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }
    }
}
