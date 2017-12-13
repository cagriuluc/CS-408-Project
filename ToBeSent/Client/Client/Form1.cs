﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;



namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        string opponent = "";
        bool terminating = false;
        static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string username = "";
        void sendUsername(string name)
        {

            byte[] buffer = Encoding.Default.GetBytes(name);
            clientSocket.Send(buffer);

        }
        public string CropString(string s)
        {
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '\0')
                {
                    result += s[i];
                }
                else if (s[i] == '\0')
                {
                    return result;
                }
            }

            return result;


        }
        private void sendInvitation(string username) // username is the receiver's name
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("0I" + username); //0I is a tag for an invitation
                clientSocket.Send(buffer);
                richTextBox.AppendText("Invitation sent.\n");
            }
            catch
            {
                terminating = true;
                clientSocket.Close();
                richTextBox.AppendText("ERROR: Invitation could not be sent.\n");
            }

        }
        private void sendResponse(string un, string res)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("2I" + res + un); //2I is the tag for the user un's response to the invitation
                clientSocket.Send(buffer);
                richTextBox.AppendText("Your response is sent to the server.\n");
            }
            catch
            {
                terminating = true;
                clientSocket.Close();
                richTextBox.AppendText("ERROR: Your response could not be sent.\n");
            }
        }
        void sendMessage(string message)
        {

            byte[] buffer = Encoding.Default.GetBytes("0M" + message); //0M is a tag for a message
            clientSocket.Send(buffer);
            richTextBox.AppendText("Message sent.\n");


        }
        public void receiveInvitation(string username) // username is the name of the sender of an invitation
        {
            richTextBox.AppendText("Invitation received from " + username + "\n");
            Pop_up invitation = new Pop_up(username);
            DialogResult newdialogResult = invitation.ShowDialog();
            
            if(newdialogResult == DialogResult.Yes)
            {
                if (opponent == "")
                {
                    sendResponse(username, "y");
                    opponent = username;
                }

                else
                {
                    richTextBox.AppendText("You are already in game, cannot accept invitation" + "\n");
                }
            }

            else if (newdialogResult == DialogResult.No)
            {
                sendResponse(username, "n");
            }

            
            
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
                    string message = CropString(raw_message.Substring(2));
                    //1L is an element of the list of players
                    //2L is the last element of the list of players
                    //1M is a message from the server that is broadcast
                    //1I is an invitation from the server
                    //3I is a message from the server saying that the game has started
                    //5I is a message from the server stating the winner of the game
                    if (raw_message.Substring(0, 2) == "1L")
                    {
                        player_list.AppendText( message + "\n");
                    }
                    else if (control == "2L")
                    {
                        player_list.AppendText(message + "\n");
#if MAN_BUG
                        richTextBox.AppendText("Message from server: " + raw_message + "\n");
#endif
                        richTextBox.AppendText("Player list is received.\n");

                    }
                    else if (control == "1M")
                    {
                        
                        richTextBox.AppendText(message);
                    }
                    else if (control == "1I")
                    {
                        Thread thrInvitation;
                        thrInvitation = new Thread( () => receiveInvitation(message));
                        thrInvitation.IsBackground = true;
                        thrInvitation.Start();
                        
                        
                    }
                   else if (control == "3I")
                    {
                        opponent = message;
                        richTextBox.AppendText("Your game with " + opponent + " started!\n");
                    }
                    else if (control == "5I")
                    {
                        if(message == username)
                        {
                            richTextBox.AppendText("You won the game against " + opponent + "\n");
                        }

                        else
                        {
                            richTextBox.AppendText("You lost the game against " + opponent + " :(\n");
                        }
                        
                        opponent = "";
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
        private void button_Connect_Click(object sender, EventArgs e)
        {
            bool connected = false;
            try
            {
                string userName = textBox_Username.Text;
                username = userName; //global username is set
                string serverIP = textBox_IP.Text;
                int port = Convert.ToInt32(textBox_Port.Text);
                Thread receiveThread;


                clientSocket.Connect(serverIP, port);
                connected = true;
                sendUsername(textBox_Username.Text);
                receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.Start();
                richTextBox.AppendText("Connected to the server.\n");
            }
            catch
            {
                richTextBox.AppendText("ERROR: Cannot connect to the server.\n");
                connected = false;
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            richTextBox.AppendText("Disconnecting from the server.\n");
            terminating = true;
            clientSocket.Dispose();
            clientSocket.Close();
        }

        private void Form1_Closing(object sender, EventArgs e)
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
            player_list.ResetText();
        }

        private void button_Send_Click(object sender, EventArgs e)
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

        private void button_Invite_Click(object sender, EventArgs e)
        {
            string username = "";
            username = textBox_Invite.Text;

            try
            {
#if DEBUG
                richTextBox.AppendText(username + "\n");
#endif
                sendInvitation(username);
            }
            catch
            {
                terminating = true;
                clientSocket.Close();
                richTextBox.AppendText("ERROR: Invitation could not be sent .\n");
            }
        }

        private void textBox_Message_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Surrender_Click(object sender, EventArgs e)
        {
            if (opponent != "")
            {
                byte[] buffer = Encoding.Default.GetBytes("4I" + opponent); //Sending the name of the opponent to the server
#if MAN_BUG
                 richTextBox.AppendText("Surrender sent opponent : " + opponent + "\n");
#endif
                clientSocket.Send(buffer);
                richTextBox.AppendText("Your surrender is sent :(\n");
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
