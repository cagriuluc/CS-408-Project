using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {

        static bool terminating = false;
        static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Client()
        {
            InitializeComponent();




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbConnect_Click(object sender, EventArgs e)
        {
            string serverIP = tbServerIP.Text;
            int port = Convert.ToInt32(tbPortID.Text);
            Thread receiveThread;


            client.Connect(serverIP, port);
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.Start();

        }

        private void tbSend_Click(object sender, EventArgs e)
        {

            bool terminating = true;
            string message = "";
            while (terminating)
            {
                message = tbMessage.Text;
                try
                {
                    sendMessage(message);

                }
                catch 
                {
                    terminating = false;
                    client.Close();
                }
            
            }


        }

        static void sendMessage(string message)
        {
            byte[] buffer = Encoding.Default.GetBytes(message);
            client.Send(buffer);
        }
        private void Receive()
        {
            bool connected = true;

            while (connected)
            {
                try
                {
                    byte[] buffer = new byte[64];

                    int rec = client.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }
                }
                catch
                {
                    connected = false;
                }


            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
