using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissor
{
    public partial class Form1 : Form
    {
        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint sender = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        EndPoint remote;
        string input;
        public Form1()
        {
            InitializeComponent();
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
            remote = (EndPoint)sender;
            data = new byte[1024];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Kéo";
            input = "2";
            server.SendTo(Encoding.ASCII.GetBytes(input), remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref remote);
            string kq = Encoding.ASCII.GetString(data, 0, recv);
            KetQua(input, kq);
            System.Threading.Thread.Sleep(5000);
            DialogResult time =MessageBox.Show("Ban co muon choi tiep ko?","Replay", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(time==DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                server.Close();
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            input = "3";
            server.SendTo(Encoding.ASCII.GetBytes(input), remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref remote);
            string kq = Encoding.ASCII.GetString(data, 0, recv);
            KetQua(input, kq);
            System.Threading.Thread.Sleep(5000);
            DialogResult time = MessageBox.Show("Ban co muon choi tiep ko?", "Replay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (time == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                server.Close();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Búa";
            input = "1";
            server.SendTo(Encoding.ASCII.GetBytes(input), remote);
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref remote);
            string kq = Encoding.ASCII.GetString(data, 0, recv);
            KetQua(input, kq);
            System.Threading.Thread.Sleep(5000);
            DialogResult time = MessageBox.Show("Ban co muon choi tiep ko?", "Replay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (time == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                server.Close();
                this.Close();
            }
        }
        public void KetQua(string input, string k)
        {
            if (input == "1")
            {
                if (k == "1")
                {
                    textBox3.Text = "Búa";
                    textBox2.Text = "Hòa";
                }
                if (k == "2")
                {
                    textBox3.Text = "Kéo";
                    textBox2.Text = "Thắng";
                }
                if (k == "3")
                {
                    textBox3.Text = "Bao";
                    textBox2.Text = "Thua";
                }
            }
            if (input == "2")
            {
                if (k == "1")
                {
                    textBox3.Text = "Búa";
                    textBox2.Text = "Thua";
                }
                if (k == "2")
                {
                    textBox3.Text = "Kéo";
                    textBox2.Text = "Hòa";
                }
                if (k == "3")
                {
                    textBox3.Text = "Bao";
                    textBox2.Text = "Thắng";
                }
            }
            if (input == "3")
            {
                if (k == "1")
                {
                    textBox3.Text = "Búa";
                    textBox2.Text = "Thắng";
                }
                if (k == "2")
                {
                    textBox3.Text = "Kéo";
                    textBox2.Text = "Thua";
                }
                if (k == "3")
                {
                    textBox3.Text = "Bao";
                    textBox2.Text = "Hòa";
                }
            }
        }
    }
}
