#define MAN_BUG
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
            public int score;
            public Player(Socket p, string un)
            {
                player_socket = p;
                username = un;
                in_game = false;
                score = 0;
            }

            public string GetName()
            {
                return username;

            }
        }

        public class Game
        {
            
            public string player1;
            public string player2;
            public int temp_number;
            public int temp_guess_1;
            public int temp_guess_2;
            public int score1;
            public int score2;

            public Game(string first, string second) 
            {
                player1 = first;
                player2 = second;

                temp_guess_1 = -101;
                temp_guess_2 = -101; 
                score1 = 0;
                score2 = 0;
            }

        }

        public int MakeRandom()
        {
            return NumGenerator.Next(1, 100);
        }


        int CheckGame(string gamer)
        {
            for(int i = 0; i < activeGames.Count; i++)
            {
                if(gamer == activeGames[i].player1 || gamer == activeGames[i].player2)
                {
                    return i;
                }
            }

            return -1;
        }
        Random NumGenerator = new Random();
        List<Game> activeGames = new List<Game>();
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

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] != '\0')
                {
                    result += s[i];
                }
                else if(s[i] == '\0')
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
                if (playerList[i].GetName() == un ) 
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
            richTextBox1.AppendText(Environment.NewLine +  "Message sent to " + playerList[player_no].username);


        }

        void sendList(int player_no)
        {
            byte[] buffer = new byte[64];
            for (int i = 0; i < playerList.Count - 1; i++)
            {
                SendString("1L" + playerList[i].GetName(), player_no);
                System.Threading.Thread.Sleep(30);
                //If this is not in place, two messages is taken as 1
            }
            

            SendString("2L" + playerList[playerList.Count -1].GetName(), player_no);  //2L is a tag for the last player name
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
                    //1G is a guess from a player
                    string message = CropString(raw_message.Substring(2));
                    if (control == "0M")
                    {
                        
                        string text = username + ": " + message;
                        richTextBox1.AppendText(Environment.NewLine + text);
                    }

                    else if(control == "0L")
                    {
                        richTextBox1.AppendText(Environment.NewLine + "List request is received from " + username);
                        sendList(CheckName(username));
                        richTextBox1.AppendText(Environment.NewLine + "List is sent to " + username);
                    }
                    else if(control == "0I")
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

                    else if(control == "2I")
                    {
                        
                          
                        string approval = message.Substring(0,1); // substring is y/n depending on the answer of the invitation receiver
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
                            if(approval == "n")
                            {
                                sendMessage(username +" did not accept your invitation.\n", inviter_no);
                            }

                            else if(approval == "y")
                            {
                                int invited_no = CheckName(username);
                                inviter_no = CheckName(inviter_name);
                                SendString("3I" + inviter_name, invited_no);
                                SendString("3I" + username, inviter_no);
                                playerList[invited_no].in_game = true;
                                playerList[inviter_no].in_game = true;
                                activeGames.Add(new Game(inviter_name, username));
                                activeGames[activeGames.Count - 1].temp_number = MakeRandom();

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
                            activeGames.Remove(activeGames[CheckGame(username)]);
                            playerList[opponent_no].score++;

                        }
                    }

                    else if (control == "1G")
                    {
                        int game_no = CheckGame(username);

                        if (game_no != -1)
                        {
                            if (username == activeGames[game_no].player1)
                            {
                                if (activeGames[game_no].temp_guess_2 == -101)
                                {
                                    activeGames[game_no].temp_guess_1 = Convert.ToInt32(message);
                                }

                                else
                                {
                                    if(Math.Abs(activeGames[game_no].temp_number - Convert.ToInt32(message)) < Math.Abs(activeGames[game_no].temp_number - activeGames[game_no].temp_guess_2))
                                    {
                                        //This user won the round
                                        activeGames[game_no].score1++;
                                        richTextBox1.AppendText("Round won by " + username + " against " + activeGames[game_no].player2);
                                        sendMessage("You won the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                        sendMessage("You lost the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player2));
                                    }

                                    else if(Math.Abs(activeGames[game_no].temp_number - Convert.ToInt32(message)) > Math.Abs(activeGames[game_no].temp_number - activeGames[game_no].temp_guess_2))
                                    {
                                        //Opponent won the round
                                        activeGames[game_no].score2++;
                                        richTextBox1.AppendText("Round won by " + activeGames[game_no].player2 + " against " + username);
                                        sendMessage("You won the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player2));
                                        sendMessage("You lost the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                    }

                                    else
                                    {
                                        richTextBox1.AppendText("Round is tie between " + activeGames[game_no].player2 + " and " + username);
                                        sendMessage("Round is tie! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player2));
                                        sendMessage("Round is tie! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                    }
                                }
                            }
                            
                            else if(activeGames[game_no].player2 == username)
                            {
                                if (activeGames[game_no].temp_guess_1 == -101)
                                {
                                    activeGames[game_no].temp_guess_2 = Convert.ToInt32(message);
                                }

                                else
                                {
                                    if (Math.Abs(activeGames[game_no].temp_number - Convert.ToInt32(message)) < Math.Abs(activeGames[game_no].temp_number - activeGames[game_no].temp_guess_1))
                                    {
                                        //This user won the round
                                        activeGames[game_no].score2++;
                                        richTextBox1.AppendText("Round won by " + username + " against " + activeGames[game_no].player1);
                                        sendMessage("You won the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                        sendMessage("You lost the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player1));
                                    }

                                    else if (Math.Abs(activeGames[game_no].temp_number - Convert.ToInt32(message)) > Math.Abs(activeGames[game_no].temp_number - activeGames[game_no].temp_guess_1))
                                    {
                                        //Opponent won the round
                                        activeGames[game_no].score1++;
                                        richTextBox1.AppendText("Round won by " + activeGames[game_no].player1 + " against " + username);
                                        sendMessage("You won the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player1));
                                        sendMessage("You lost the round! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                    }

                                    else
                                    {
                                        richTextBox1.AppendText("Round is tie between " + activeGames[game_no].player2 + " and " + username);
                                        sendMessage("Round is a tie! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(activeGames[game_no].player2));
                                        sendMessage("Round is a tie! " + activeGames[game_no].score1 + " - " + activeGames[game_no].score2, CheckName(username));
                                    }

                                    //if the game is not finished yet, reset game data and make new random int 
                                   
                                }
                            }
                            if (activeGames[game_no].score1 + activeGames[game_no].score2 >= 3)
                            {
                                string winner = "";
                                string loser = "";
                                if (activeGames[game_no].score1 < activeGames[game_no].score2)
                                {
                                    winner = activeGames[game_no].player2;
                                    loser = activeGames[game_no].player1;
                                }
                                else if (activeGames[game_no].score1 > activeGames[game_no].score2)
                                {
                                    winner = activeGames[game_no].player1;
                                    loser = activeGames[game_no].player2;

                                }
                                int winner_no = CheckName(winner);
                                int loser_no = CheckName(loser);


                                SendString("5I" + winner, winner_no);
                                SendString("5I" + winner, loser_no);
                                richTextBox1.AppendText(Environment.NewLine + activeGames[game_no].player1 + "-" + activeGames[game_no].player2 + " winner is " + winner);
                                richTextBox1.AppendText(Environment.NewLine + "Match result is sent to " + winner + " and " + loser);
                                playerList[winner_no].in_game = false;
                                playerList[loser_no].in_game = false;
                                activeGames.Remove(activeGames[CheckGame(winner)]);
                                playerList[winner_no].score++;
                            }
                        }

                        else
                        {
                            sendMessage("You are not in a game.\n", CheckName(username));

                        }
                    }
                }
                catch
                {
                    if (!terminating)
                        richTextBox1.AppendText(Environment.NewLine + username + " has disconnected...");

                    if(playerList[CheckName(username)].in_game == true)
                    {
                        int game_no = CheckGame(username);
                        if(activeGames[game_no].player1 == username)
                        {

                            int op_no = CheckName(activeGames[game_no].player2);
                            if(op_no != -1)
                            {
                                playerList[op_no].score++;
                                playerList[op_no].in_game = false;
                                sendMessage("Your opponent left the game... \n", op_no);
                                SendString("5I" + activeGames[game_no].player2, op_no);

                            }
                        }
                        else
                        {
                            int op_no = CheckName(activeGames[game_no].player1);
                            if (op_no != -1)
                            {
                                playerList[op_no].score++;
                                playerList[op_no].in_game = false;
                                sendMessage("Your opponent left the game... \n", op_no);
                                SendString("5I" + activeGames[game_no].player1, op_no);
                            }
                        }
                        activeGames.Remove(activeGames[game_no]);
                    }

                    n.Close();
                    bool result = playerList.Remove(playerList[CheckName(username)]);
#if MAN_BUG
                    richTextBox1.AppendText(Environment.NewLine + username + "is removed from the player list? " + result);
#endif
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
