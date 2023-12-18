using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server1512
{
    public partial class Form1 : Form
    {
        List<string> users = new List<string>(); //users list
        List<Socket> spsSockets = new List<Socket>(); //sps subs socket list
        List<Socket> ifSockets = new List<Socket>(); // if subs socket list
        List<string> spsSubscribers = new List<string>(); //sps subs name list
        List<string> ifSubscribers = new List<string>(); // if subs name list
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        bool terminating = false;
        bool listening = false; // listening flag
        public Form1()
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            Control.CheckForIllegalCrossThreadCalls = false;
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            List<Socket> clientSockets = new List<Socket>();
            InitializeComponent();
        }
        //server form closing handler sends a message to clients
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            foreach (Socket users in clientSockets) {
                string disconnect = "Server has disconnected";
                Byte[] buffer11 = Encoding.Default.GetBytes(disconnect);
                users.Send(buffer11);
            }
            Environment.Exit(0);
        }
        //listen click handler
        private void Listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                Listen.Enabled = false;


                //opens a new thread for every client
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                server_actions.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else //port number mistake check
            {
                server_actions.AppendText("User needs to check port number \n");
            }
        }
        private void Accept()
        {
            
            while (listening)
            {

                try
                {

                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start(); // start a threadh to listen
                }
                catch
                {
                    if (terminating) // closing check
                    {
                        listening = false;
                    }
                    else
                    {
                        server_actions.AppendText("The socket stopped working.\n");
                        Byte[] buffer0 = Encoding.Default.GetBytes("*The socket stopped working.\n");

                    }

                }
            }
        }
        // method to handle client - server interaction
        private void Receive(Socket thisClient) // updated
        {
            bool connected = true;
            bool first = true;
            string name = ""; // name of the client
            while (connected && !terminating)
            {
                
                try
                {
                    
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);
                
                    string Message = Encoding.Default.GetString(buffer);
                    if (first)
                    {
                        name = Message; // first message from user is name
                        if (!users.Contains(Message)) //check the username 
                        {
                            server_actions.AppendText(name);
                            server_actions.AppendText(" connected succesfully.\n");
                            Byte[] buffer1 = Encoding.Default.GetBytes("successful");
                            thisClient.Send((buffer1));
                            users.Add(name);
                            first = false;
                            Updatelist(connected_clients, users);
                        }
                        else
                        {
                            server_actions.AppendText(Message);
                            server_actions.AppendText(" couldn't connect: username already exists.\n");
                            Byte[] buffer2 = Encoding.Default.GetBytes("unsuccesful");
                            thisClient.Send(buffer2);
                            thisClient.Close();
                            clientSockets.Remove(thisClient);
                            connected = false;
                        }
                    }
                    else
                    {
                       
                        if (Message.Contains("subscribe") || Message.Contains("unfollow")) //check the operation for sub/unsub to a channel
                        {
                            
                            string[] splitted = Message.Split(',');

                            if (splitted[0].Contains( "subscribe")) // sub operations
                            {
                               
                                if (splitted[1].Contains( "sps"))
                                {
                                    spsSubscribers.Add(name);
                                    spsSockets.Add(thisClient);
                                    server_actions.AppendText(splitted[2]);
                                    server_actions.AppendText(" joined the SPS101 channel.\n");
                                    Updatelist(SPS101, spsSubscribers);
                                    foreach (Socket user in spsSockets)
                                    {
                                        Byte[] buffer3 = Encoding.Default.GetBytes(Message);
                                        user.Send(buffer3);
                                    }



                                }
                                else
                                {
                                    
                                    ifSubscribers.Add(name);
                                    ifSockets.Add(thisClient);
                                    server_actions.AppendText(splitted[2]);
                                    server_actions.AppendText(" joined the IF100 channel.\n");
                                    Updatelist(IF100, ifSubscribers);
                                    foreach (Socket user in ifSockets)
                                    {
                                        Byte[] buffer4 = Encoding.Default.GetBytes(Message);
                                        user.Send(buffer4);
                                   
                                    }
                                }
                            }
                            else //unsub operations
                            {

                                if (splitted[1].Contains("sps"))
                                {
                                    
                                    server_actions.AppendText(splitted[2]);
                                    server_actions.AppendText(" leaved the SPS101 channel.\n");
                                    
                                    foreach (Socket user in spsSockets)
                                    {
                                        Byte[] buffer5 = Encoding.Default.GetBytes(Message);
                                        user.Send(buffer5);
                                    }

                                    spsSubscribers.Remove(name);
                                    Updatelist(SPS101, spsSubscribers);
                                    spsSockets.Remove(thisClient);
                                    Updatelist(SPS101, spsSubscribers);


                                }
                                else
                                {
                                    
                                    server_actions.AppendText(splitted[2]);
                                    server_actions.AppendText(" leaved the IF100 channel.\n");
                                   
                                    foreach (Socket user in ifSockets)
                                    {
                                        Byte[] buffer6 = Encoding.Default.GetBytes(Message);
                                        user.Send(buffer6);
                                    }
                                    
                                    ifSubscribers.Remove(name);
                                    Updatelist(IF100, ifSubscribers);
                                    ifSockets.Remove(thisClient);
                                    Updatelist(IF100, ifSubscribers);
                                }
                            }

                        }
                        else // handle messages send by users
                        {
                            string[] splitted = Message.Split(',');

                            if (splitted[2].Contains("IFmessage"))
                            {
                                server_actions.AppendText("[IF100]- ");
                                server_actions.AppendText(splitted[0]);
                                server_actions.AppendText(": ");
                                server_actions.AppendText(splitted[1]);
                                server_actions.AppendText("\n");
                                foreach (Socket user in ifSockets)
                                {
                                    Byte[] buffer6 = Encoding.Default.GetBytes(splitted[2] + "," + splitted[0] + "," + splitted[1]);
                                    user.Send(buffer6);
                                }
                            }
                            else
                            {
                                server_actions.AppendText("[SPS101]- ");
                                server_actions.AppendText(splitted[0]);
                                server_actions.AppendText(": ");
                                server_actions.AppendText(splitted[1]);
                                server_actions.AppendText("\n");
                                foreach (Socket user in spsSockets)
                                {
                                    Byte[] buffer7 = Encoding.Default.GetBytes(splitted[2] + "," + splitted[0] + "," + splitted[1]);
                                    user.Send(buffer7);
                                }
                            }
                        }
                    }


                }
                catch
                {
                    if (!terminating) //check for user disconnecting
                    {
                        server_actions.AppendText(name);
                        server_actions.AppendText(" has disconnected\n");
                    }
                    Updatelist(connected_clients, users); //update the user list
                    if (spsSubscribers.Contains(name)) // update the sps list
                    {
                        spsSubscribers.Remove(name);
                        spsSockets.Remove(thisClient);
                        Updatelist(SPS101, spsSubscribers);
                        foreach (Socket user in spsSockets)
                        {
                            Byte[] buffer10 = Encoding.Default.GetBytes("sps,"+ name);
                            user.Send(buffer10);
                        }
                    }
                    if (ifSubscribers.Contains(name)) //update the if list
                    {
                        ifSubscribers.Remove(name);
                        ifSockets.Remove(thisClient);
                        Updatelist(IF100, ifSubscribers);
                        foreach (Socket user in spsSockets)
                        {
                            Byte[] buffer11 = Encoding.Default.GetBytes("if," + name);
                            user.Send(buffer11);
                        }
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    users.Remove(name);
                    Updatelist(connected_clients, users);
                    connected = false;
                }
            }
        } 
        //function to update lists
        public void Updatelist(RichTextBox richtextbox, List<string> list)
        {
            // Clear the current content of the TextBox
            richtextbox.Clear();

            // Add each username to the TextBox
            foreach (string user in list)
            {
                
                richtextbox.AppendText(user);
                richtextbox.AppendText("\n");
            }
        }

        private void server_actions_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
