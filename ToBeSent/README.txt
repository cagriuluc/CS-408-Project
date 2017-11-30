01/11/2017
Project done by Cansu Ülker and Çagri Uluç Yildirimoglu

Client Side
----------------
-Each client can connect, disconnect to the server or ask for the usernames of other players.
-Each client connects to the server via their username.
 Usernames are stored in the server side to send to the client whenever a client presses "List Players" button.
-A client can send messages to the server. The messaging functionality between clients is not implemented yet.


Server Side
----------------
-In order for clients and the server to make different requests etc. any message sent from the server and 
 the clients is tagged by the first two letters of the string that it sends. 
 So first two letter of any string that is sent between the two sides are reserved for control tags.

 General
---------
-All of the activities stated above are printed to the "Activities" log.
-In the Client file, the t file named "Player" contains the code. We could not change the filename
 to Client. 
-In the Server file, the file named "CS408_Servre" contains the code. We could not change the filename to Server

