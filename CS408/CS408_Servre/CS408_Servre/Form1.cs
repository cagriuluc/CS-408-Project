using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408_Servre


{
    

    public partial class Form1 : Form
    {
        public class Player
        {

            public Socket player_socket;
            public string username;
            public Player(Socket p, string un)
            {
                player_socket = p;
                username = un;
            }

            public string GetName()
            {
                return username;

            }
        }

        bool listening = false;
        bool terminating = false;
        bool accept = true;
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Player> playerList = new List<Player>();
        int port_no;
        Thread thrAccept;
        //these are taken from Lab 2 of CS 408 course

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public int CheckName(string un)
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].GetName() == un ) 
                {
                    return i;
                }
            }
            return -1;
        }

        private void listen_button_Click(object sender, EventArgs e)
        {
           

            port_no = Convert.ToInt32(port_text_box.Text);
            
            server.Bind(new IPEndPoint(IPAddress.Any, port_no));
            server.Listen(3);
            richTextBox1.AppendText(Environment.NewLine + "Started listening to Port " + port_no);
            thrAccept = new Thread(new ThreadStart(Accept));
            thrAccept.Start();
            thrAccept.IsBackground = true;
            listening = true;

        }

        void sendMessage(string message, int player_no)
        {

            byte[] buffer = Encoding.Default.GetBytes("0M" + message); //0M is a tag for a message
            playerList[player_no].player_socket.Send(buffer);
            richTextBox1.AppendText(Environment.NewLine +  "Message sent.");


        }

        void sendList(int player_no)
        {
            byte[] buffer = new byte[64];
            for (int i = 0; i < playerList.Count - 1; i++)
            {
                buffer = Encoding.Default.GetBytes("1L" + playerList[i].GetName()); //1L is a tag for a player name
                playerList[player_no].player_socket.Send(buffer);
                
            }
            buffer = Encoding.Default.GetBytes("2L" + playerList[playerList.Count-1].GetName()); //2L is a tag for the last player name
            playerList[player_no].player_socket.Send(buffer);

        }

        //this function will be used in the ThrAccept
        //so that new clients will be able to connect even if server is busy (with sending messages)
        private void Accept()
        {
            while (accept)
            {
                try
                {
                    Socket current = server.Accept();
                    byte[] buffer = new byte[64];
                    int rec = current.Receive(buffer);
                    string uname = Encoding.Default.GetString(buffer);
                    if (CheckName(uname) != -1)
                    {
                        richTextBox1.AppendText(Environment.NewLine + "New player could not be added. Reason: Same username with anothe player.");
                        current.Close();
                        continue;
                    }
                    Player newPlayer = new Player(current, uname);
                    playerList.Add(newPlayer);
                    richTextBox1.AppendText(Environment.NewLine + "New player with username " + uname + " added.");
                    Thread thrReceive;
                    thrReceive = new Thread(new ThreadStart(Receive));
                    thrReceive.Start();
                    thrReceive.IsBackground = true;
                }
                catch
                {
                    if (terminating)
                        accept = false;
                    else
                        richTextBox1.AppendText(Environment.NewLine + "Listening socket has stopped listening...");

                }
            }
        }

        private void Receive()
        {
            bool connected = true;
            Socket n = playerList[playerList.Count - 1].player_socket;
            string username = playerList[playerList.Count - 1].username;
            while (connected)
            {
                try
                {
                    Byte[] buffer = new byte[64];
                    int rec = n.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string raw_message = Encoding.Default.GetString(buffer);
                    string control = raw_message.Substring(0, 2);
                    //0M is a message to the lobby from a player
                    //0L is a request from the player for the player list
                    //0I is an invitation from a player
                    if (control == "0M")
                    {
                        raw_message = raw_message.Substring(0, raw_message.IndexOf("\0")); 
                        string text = username + ": " + raw_message;
                        richTextBox1.AppendText(Environment.NewLine + text);
                    }

                    if(control == "0L")
                    {
                        richTextBox1.AppendText(Environment.NewLine + "List request is received from " + username);
                        sendList(CheckName(username));
                        richTextBox1.AppendText(Environment.NewLine + "List is sent to " + username);
                    }
                    if(control == "0I")
                    {
                        richTextBox1.AppendText(Environment.NewLine + "Invitation is received from " + username);
                       // not completed kafa yetmedi

                    }
                
                }
                catch
                {
                    if (!terminating)
                        richTextBox1.AppendText(Environment.NewLine + username + " has disconnected...");
                    n.Close();
                    playerList.Remove(playerList[CheckName(username)]);
                    connected = false;
                }
            }

        }

        private void port_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //new function to send invitation
        void sendInvitation(string sname, int player_no) //sname is the name of the player who sent the invitation 
        {
            string rname = playerList[player_no].GetName(); //rname is the name of the player who receives the invitation
            byte[] buffer = Encoding.Default.GetBytes("0I" + sname); //0I is a tag for the invitation
            playerList[player_no].player_socket.Send(buffer);
            richTextBox1.AppendText(Environment.NewLine + "Invitation sent to ." + rname);

        }
    }
}
