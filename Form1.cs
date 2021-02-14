using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RGBlamp1
{
    public partial class Form1 : Form
    {
        public SerialPort a;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;
        }

        bool flash,poor, r, g, b, w;

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(portName);
            }
            a = new SerialPort();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (a.IsOpen == false)
            {
                a.BaudRate = 9600;
                a.PortName = comboBox1.SelectedItem.ToString();
                a.Parity = Parity.None;
                a.DataBits = 8;
                a.StopBits = StopBits.One;
                a.Open();
                button5.Text = "Disconnect";
                comboBox1.Enabled = false;
                groupBox1.Enabled = true;
                groupBox4.Enabled = true;
            } else
            {
                a.Close();
                button5.Text = "Connect";
                comboBox1.Enabled = true;
                groupBox1.Enabled = false;
                groupBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (r == false)
            {
                a.Write("1");
                button1.Text = "D";
                r = true;
            } else
            {
                a.Write("6");
                button1.Text = "E";
                r = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a.Write("9");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(a.IsOpen)
            {
                if (flash == true)
                {
                    a.Write("4");
                }
                else
                {
                    a.Write("9");
                }
                a.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(a.IsOpen)
            {
                a.Write("1000");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(poor == false)
            {
                a.Write("30");
                button8.Text = "Dark";
                poor = true;
            } else
            {
                a.Write("31");
                button8.Text = "Normal";
                poor = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g == false)
            {
                a.Write("2");
                button2.Text = "D";
                g = true;
            }
            else
            {
                a.Write("7");
                button2.Text = "E";
                g = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                a.Write("3");
                button3.Text = "D";
                b = true;
            }
            else
            {
                a.Write("8");
                button3.Text = "E";
                b = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (flash == false)
            {
                button6.Text = "Stop";
                a.Write("4");
                flash = true;
            } else
            {
                button6.Text = "Flash";
                a.Write("4");
                flash = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (w == false)
            {
                a.Write("10");
                button7.Text = "D";
                w = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                a.Write("11");
                button7.Text = "E";
                w = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
