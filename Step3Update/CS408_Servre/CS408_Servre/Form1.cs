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
            public bool in_game;
            public int globalPoint;
            public Player(Socket p, string un)
            {
                player_socket = p;
                username = un;
                in_game = false;
                globalPoint = 0;
            }

            public string GetName()
            {
                return username;

            }

            public int GetPoint()
            {
                return globalPoint;
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

        public int CheckName(string un)
        {
#if MAN_BUG
            richTextBox1.AppendText(Environment.NewLine + playerList.Count);

            richTextBox1.AppendText(Environment.NewLine + un);

            
#endif
            for (int i = 0; i < playerList.Count; i++)
            {
#if MAN_BUG
                richTextBox1.AppendText(Environment.NewLine + i);

                richTextBox1.AppendText(Environment.NewLine + playerList[i].GetName());


#endif
                if (playerList[i].GetName() == un)
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

        void SendString(string data, int player_no)
        {
            byte[] buffer = Encoding.Default.GetBytes(data);
            playerList[player_no].player_socket.Send(buffer);
        }

        void sendMessage(string message, int player_no)
        {

            SendString("1M" + message, player_no); //1M is the tag for a message
            richTextBox1.AppendText(Environment.NewLine + "Message sent to " + playerList[player_no].username);


        }

        void sendList(int player_no)
        {
            byte[] buffer = new byte[64];
            for (int i = 0; i < playerList.Count - 1; i++)
            {
                SendString("1L" + playerList[i].GetName() + playerList[i].GetPoint(), player_no); //buraya playerList[i].GetPoint() ekledim
                System.Threading.Thread.Sleep(30);
            }

            SendString("2L" + playerList[playerList.Count - 1].GetName(), player_no);  //2L is a tag for the last player name
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
                    string uname = CropString(Encoding.Default.GetString(buffer));
#if MAN_BUG
                    richTextBox1.AppendText(Environment.NewLine + uname);
                    richTextBox1.AppendText(Environment.NewLine + "length: " + uname.Length);
#endif

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
                    //2I is the response to an invitation
                    //4I is surrender from a player
                    //1G is the beginning of the game
                    //2G is the guess of a player
                    string message = CropString(raw_message.Substring(2));
                    if (control == "0M")
                    {

                        string text = username + ": " + raw_message;
                        richTextBox1.AppendText(Environment.NewLine + text);
                    }

                    else if (control == "0L")
                    {
                        richTextBox1.AppendText(Environment.NewLine + "List request is received from " + username);
                        sendList(CheckName(username));
                        richTextBox1.AppendText(Environment.NewLine + "List is sent to " + username);
                    }
                    else if (control == "0I")
                    {
                        int rno = CheckName(message);

                        if (rno == -1)
                        {
#if MAN_BUG
                            richTextBox1.AppendText(Environment.NewLine + CheckName("cagri"));
                            richTextBox1.AppendText(Environment.NewLine + raw_message + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine + message + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine + rno + Environment.NewLine);

#endif
                            sendMessage("\nPlayer was not found :(", CheckName(username));
                            richTextBox1.AppendText(Environment.NewLine + "Unsuccessful invite from " + username + ", player is not connected");

                        }
                        else if (playerList[rno].in_game == true)
                        {
                            sendMessage("\nPlayer is already in a game :(", CheckName(username));
                            richTextBox1.AppendText(Environment.NewLine + "Unsuccessful invite from " + username + ", player is in a game");

                        }
                        else
                        {
                            richTextBox1.AppendText(Environment.NewLine + "Invitation is received from " + username + " to " + message);
                            SendInvitation(username, message); //message is receipient username in this case

                        }
                    }

                    else if (control == "2I")
                    {


                        string approval = message.Substring(0, 1); // substring is y/n depending on the answer of the invitation receiver
                        string inviter_name = message.Substring(1);
                        int inviter_no = CheckName(inviter_name);

                        if (inviter_no == -1)
                        {
                            sendMessage("Sorry, player is disconnected.\n", CheckName(username));
                            richTextBox1.AppendText(Environment.NewLine + "Inviter was not found: " + inviter_name);

                        }
                        else if (playerList[inviter_no].in_game == true)
                        {
                            sendMessage("Sorry, player is already in game.\n", CheckName(username));

                        }
                        else
                        {
                            if (approval == "n")
                            {
                                sendMessage(username + " did not accept your invitation.\n", inviter_no);
                            }

                            else if (approval == "y")
                            {

                                int invited_no = CheckName(username);
                                inviter_no = CheckName(inviter_name);
                                SendString("3I" + inviter_name, invited_no);
                                SendString("3I" + username, inviter_no);
                                playerList[invited_no].in_game = true;
                                playerList[invited_no].in_game = true;

                                Random r = new Random(); // secretnum olusturuluyor, oyunculara notification yollaniyor
                                int secretNumber = r.Next(0, 100);
                                SendString("1G" + "Guess the secret number.\n" + inviter_name, invited_no);
                                SendString("1G" + "Guess the secret number.\n" + inviter_name, inviter_no);

                            }
                        }


                    }
                    else if (control == "4I")
                    {

                        string opponent_name = message; //substring is opponent's name
                        int user_no = CheckName(username);
                        int opponent_no = CheckName(opponent_name);
                        if (playerList[opponent_no].in_game && playerList[opponent_no].in_game) //check is added in case surrender moments are very close
                        {
                            SendString("5I" + opponent_name, user_no);
                            SendString("5I" + opponent_name, opponent_no);
                            richTextBox1.AppendText(Environment.NewLine + username + "-" + opponent_name + " winner is " + opponent_name);
                            richTextBox1.AppendText(Environment.NewLine + "Match result is sent to " + username + " and " + opponent_name);
                            playerList[user_no].in_game = false;
                            playerList[opponent_no].in_game = false;
                        }
                    }
                    else if (control == "2G")
                    {
                       string opponent_name = CropString(message.Substring())



                    }
                }
                catch
                {
                    if (!terminating)
                        richTextBox1.AppendText(Environment.NewLine + username + " has disconnected...");

                    n.Close();

                    richTextBox1.AppendText(Environment.NewLine + username + "is removed from the player list? " + playerList.Remove(playerList[CheckName(username)]));

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
        void SendInvitation(string sname, string rname) //sname is the name of the player who sent the invitation 
        {
            int player_no = CheckName(rname);
            SendString("1I" + sname, player_no); //1I is a tag for the invitation
            richTextBox1.AppendText(Environment.NewLine + "From " + sname + " invitation sent to " + rname);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
