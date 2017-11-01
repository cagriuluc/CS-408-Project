/*---CLIENT SIDE---
   Players are able to send messages to other players.
   They can request a list of players from the server.
   They can connect/disconnect to the server.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

namespace Player
{
    public partial class Client : Form
    {
        bool terminating = false;
        static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            bool connected = false;
            try
            {
                string userName = textBox_username.Text;
                string serverIP = textBox_IP.Text;
                int port = Convert.ToInt32(textBox_Port.Text);
                Thread receiveThread;


                clientSocket.Connect(serverIP, port);
                connected = true;
                sendUsername(textBox_username.Text);
                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.Start();
                richTextBox.AppendText("Connected to the server.");
            }
            catch
            {
                richTextBox.AppendText("ERROR: Cannot connect to the server.\n");
                connected = false;
            }
        }


        void sendMessage(string message)
        {
            
                byte[] buffer = Encoding.Default.GetBytes("0M" + message); //0M is a tag for a message
                clientSocket.Send(buffer);
                richTextBox.AppendText("Message sent.\n");
            

        }
        void sendUsername(string name)
        {
          
                byte[] buffer = Encoding.Default.GetBytes(name);
                clientSocket.Send(buffer);
            
        }
        private void Receive()
        {
            bool connected = true;
         
            while (connected)
            {
                try
                {
                    byte[] buffer = new byte[64];

                    int rec = clientSocket.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }
                    string raw_message = Encoding.Default.GetString(buffer);
                    string control = raw_message.Substring(0, 2);
                    //1L is an element of the list of players
                    //2L is the last element of the list of players
                    //1M is a message from the server that is broadcast
                    if (raw_message.Substring(0,2) == "1L")
                    {
                        player_list.AppendText(raw_message.Substring(2));
                    }
                    if(control == "2L")
                    {
                        player_list.AppendText(raw_message.Substring(2));
                        player_list.AppendText("Player list is received.");
                    }
                    if(control == "1M")
                    {
                        player_list.AppendText(raw_message.Substring(2));
                    }
                }
                catch
                {
                    if (!terminating)
                        richTextBox.AppendText("Connection has been terminated.\n");
                    connected = false;
                }


            }

        }

        private void button_Send_Click(object sender, EventArgs e) //a function to send messages between players
        {
           
            string message = "";
         
                message = textBox_Message.Text;
                try
                {
                    sendMessage(message);

                }
                catch
                {
                    terminating = true;
                    clientSocket.Close();
                    richTextBox.AppendText("ERROR: Message could not be sent.\n");
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            richTextBox.AppendText("Disconnecting from the server.\n");
            terminating = true;
            clientSocket.Dispose();
            clientSocket.Close();
        }

        private void button_List_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Default.GetBytes("0L"); //0L is a tag for the request of list of the players
            clientSocket.Send(buffer);
            richTextBox.AppendText("Player list request sent.\n");

        }

    }
}
