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
using System.Net;

namespace Server
{
    public partial class Server : Form
    {

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool terminating = true;
        bool listening = false;

        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbListen_Click(object sender, EventArgs e)
        {
            int serverPort = Convert.ToInt32(tbServerPort.Text);
            Thread acceptThread;


            try
            {

                server.Bind(new IPEndPoint(IPAddress.Any, serverPort));
                server.Listen(3);
                acceptThread = new Thread(new ThreadStart(Accept));
                acceptThread.Start();
                listening = true;


            }

            catch
            {

                server.Close();
                listening = false;
            }


        }

        private void listen()
        {

        }

        private void Accept()
        {

            bool accept = true;


            List<Socket> socketList = new List<Socket>();
            while (accept)
            {
                try
                {
                    socketList.Add(server.Accept());

                    Thread receiveThread;
                    receiveThread = new Thread(new ThreadStart(Receive));
                    receiveThread.Start();
                }
                catch
                {
                    terminating = false;
                    server.Close();
                }
            }
        }

        static private void Receive()
        {
            List<Socket> socketList = new List<Socket>();
            bool terminating = true;
            bool connected = true;
          
            Socket n = socketList[socketList.Count];

            while (connected && socketList.Count >= 1)
            {
                try
                {
                    Byte[] buffer = new byte[64];
                    int rec = n.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string newmessage = Encoding.Default.GetString(buffer);

                }
                catch
                {
                    if (!terminating)

                        n.Close();
                    socketList.Remove(n);
                    connected = false;
                }
            }
        }

        private void tbServerPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
