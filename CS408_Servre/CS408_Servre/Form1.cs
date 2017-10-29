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
    public class Player
    {
       
        public Socket player_socket;
        string username;
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

    public partial class Form1 : Form
    {
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
        }

        public bool CheckName(string un)
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].GetName() == un ) //undonee....
                {
                    return true;
                }
            }
            return false;
        }

        private void listen_button_Click(object sender, EventArgs e)
        {
           

            port_no = Convert.ToInt32(port_text_box.Text);
            server.Bind(new IPEndPoint(IPAddress.Any, port_no));
            server.Listen(3);
            richTextBox1.AppendText(Environment.NewLine + "Started listening to Port " + port_no);
            thrAccept = new Thread(new ThreadStart(Accept));
            thrAccept.Start();
            listening = true;

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
                    if (CheckName(uname))
                    {
                        richTextBox1.AppendText(Environment.NewLine + "New player could not be added. Reason: Same username with anothe player.");
                        continue;
                    }
                    Player newPlayer = new Player(current, uname);//problem
                    playerList.Add(newPlayer);
                    richTextBox1.AppendText(Environment.NewLine + "New player with username " + uname + " added.");
                    Thread thrReceive;
                    thrReceive = new Thread(new ThreadStart(Receive));
                    thrReceive.Start();
                }
                catch
                {
                    if (terminating)
                        accept = false;
                    else
                        Console.Write("Listening socket has stopped working...\n");
                }
            }
        }

        private void Receive()
        {
            bool connected = true;
            Socket n = playerList[playerList.Count - 1].player_socket;

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

                    string newmessage = Encoding.Default.GetString(buffer);
                    newmessage = newmessage.Substring(0, newmessage.IndexOf("\0"));
                    Console.Write("Client: " + newmessage + "\r\n");
                }
                catch
                {
                    if (!terminating)
                        Console.Write("Client has disconnected...\n");
                    n.Close();
                    playerList.Remove(playerList[playerList.Count-1]);
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
    }
}
