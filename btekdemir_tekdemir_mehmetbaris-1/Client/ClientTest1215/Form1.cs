using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//last version

namespace ClientTest1215
{
    public partial class Form1 : Form
    {
        
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            string username1 = username.Text;
        }
        string username1;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //when user closed the gui
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
        //if100 channels subscribe button handler
        private void if_subscribe_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string channel = "if"; // channel identifier

            if (clickedButton.Text == "subscribe")
            {
                
                string subscribe = "subscribe*";
                string data = subscribe + "," + channel + "," + username1;
                if_send.Enabled = true;
                clickedButton.Text = "unsubscribe";
                Byte[] buffer = Encoding.Default.GetBytes(data);
                
                clientSocket.Send(buffer);
                
            }
            else
            {
                string unsubscribe = "unfollow*";
                string data = unsubscribe + "," + channel + "," + username1;
                if_send.Enabled = false;
                clickedButton.Text = "subscribe";
                
                Byte[] buffer = Encoding.Default.GetBytes(data);
                clientSocket.Send(buffer);
            }
         
        }
        // sps101 channels subscribe button handler 
        private void sps_subscribe_Click(object sender, EventArgs e)
        {   
            string channel = "sps";
            
            Button clickedButton = (Button)sender;

            if (clickedButton.Text == "subscribe")
            {
                string subscribe = "subscribe*";
                string data = subscribe + "," + channel + "," + username1;
                sps_send.Enabled = true;
                clickedButton.Text = "unsubscribe";
                Byte[] buffer44 = Encoding.Default.GetBytes(data);

                clientSocket.Send(buffer44);
            }
            else
            {

                string unsubscribe = "unfollow*";
                string data = unsubscribe + "," + channel + "," + username1;
                sps_send.Enabled = false;
                clickedButton.Text = "subscribe";
                Byte[] buffer44 = Encoding.Default.GetBytes(data);
                clientSocket.Send(buffer44);
            }
            
        }
        // event handler for connect click button
        private void connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = ip.Text;
            if (!String.IsNullOrEmpty(IP))
            {

                // try to connect
                int portNum;
                if (Int32.TryParse(port.Text, out portNum))
                {
                    try
                    {

                        clientSocket.Connect(IP, portNum);
                        connect.Enabled = false;
                        connected = true;

                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();
                        Disconnect.Enabled = true;
                        string message = username.Text;

                        if (message != "" && message.Length <= 20) //check the username 
                        {
                            Byte[] buffer = Encoding.Default.GetBytes(message);
                            clientSocket.Send(buffer);
                            actions.AppendText(message + "'s username is sent successfully\n");
                        }

                        else
                        {
                            actions.AppendText("username is not appropriate!\n");
                            connect.Enabled = true;
                        }


                    }
                    catch //any connection issues regarding the server 
                    {
                        actions.AppendText("Could not connect to the server: Check the IP or Port number! or Check the server status!\n");

                        connect.Enabled = true;
                    }
                }
                else
                {
                    actions.AppendText("Couldn't connect to the server: Check the Port number or Don't leave empty fields!\n");
                }
            }
            //check if the ip number is entered
            else { 
                actions.AppendText("Please enter an IP number!");
            }
        }

        private void Receive() // handle messages from server
        {   
            bool first = true;
            while (connected)
            {

                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);

                    if (first) // check if the send value is username
                    {
                        if (incomingMessage.Contains("successful")) // check if the username already exists
                        {
                          
                            actions.AppendText("Username is valid, connected succesfully.\n");
                            username1 = username.Text;
                            messagebox.Enabled = true;
                            if_subscribe.Enabled = true;
                            sps_subscribe.Enabled = true;
                            connected = true;
                            
                            first = false;
                        }
                        else 
                        {
                            actions.AppendText("Username already exists, connection failed.\n");
                            first = false;
                            connected = false;
                            Disconnect.Enabled = false;
                            connect.Enabled = true;
                        }
                    }
                    else if(incomingMessage.Contains("Server has disconnected")){ // chechk if the server send a message that it disconnected
                        actions.AppendText(incomingMessage);
                        actions.AppendText("\n");
                        connect.Enabled = true;
                        connected = false;
                        terminating = true;
                        Disconnect.Enabled = false;
                        connect.Enabled = true;
                        if_subscribe.Enabled = false;
                        sps_subscribe.Enabled = false;
                        if_send.Enabled = false;
                        sps_send.Enabled = false;
                        messagebox.Enabled = false;
                        clientSocket.Close();
                        connected = false;
                        sps_subscribe.Text = "subscribe";
                        if_subscribe.Text = "subscribe";
                    }

                    else
                    {


                        if (incomingMessage.Contains("unfollow*,") || incomingMessage.Contains("subscribe*,")) //check the send value for a subs/unsub operation
                        {

                            string[] splitted = incomingMessage.Split(',');
                            if (splitted[0] == "unfollow*") 
                            {
                                if (splitted[1] == "sps")
                                {
                                    sps_channel.AppendText(splitted[2]);
                                    sps_channel.AppendText(" unsubscribed from SPS101 channel.\n");
                                    actions.AppendText(splitted[2]);
                                    actions.AppendText(" unsubscribed from SPS101 channel.\n");
                                }
                                else
                                {
                                    if_channel.AppendText(splitted[2]);
                                    if_channel.AppendText(" unsubscribed from IF100 channel.\n");
                                    actions.AppendText(splitted[2]);
                                    actions.AppendText(" unsubscribed from IF100 channel.\n");
                                }
                            }
                            else
                            {

                                if (splitted[1] == "sps")
                                {
                                    sps_channel.AppendText(splitted[2]);
                                    sps_channel.AppendText(" subscribed to SPS101 channel.\n");
                                    actions.AppendText(splitted[2]);
                                    actions.AppendText(" subscribed to SPS101 channel.\n");
                                }
                                else
                                {
                                    if_channel.AppendText(splitted[2]);
                                    if_channel.AppendText(" subscribed to IF100 channel.\n");
                                    actions.AppendText(splitted[2]);
                                    actions.AppendText(" subscribed to IF100 channel.\n");
                                }
                            }
                        }
                        
                        else //if it is not sub/unsub operation then message
                        {

                            string[] ayir = incomingMessage.Split(',');

                            if (ayir[0].Contains("IFmessage")) //check the message for channel to be send
                            {
                                if_channel.AppendText(ayir[1] + ": " + ayir[2] + "\n");
                            }
                            else if (ayir[0].Contains("SPSmessage"))
                            {
                                sps_channel.AppendText(ayir[1] + ": " + ayir[2] + "\n");
                            }
                            else if(ayir[0].Contains("if")) {
                                if_channel.AppendText(ayir[1]);
                                if_channel.AppendText(" has left the channel.");
                            }
                            else if (ayir[0].Contains("sps"))
                            {
                                sps_channel.AppendText(ayir[1]);
                                sps_channel.AppendText(" has left the channel.");
                            }
                        }
                    }


                }
                catch // any error thrown
                {
                    if (!terminating) 
                    {
                        
                        connect.Enabled = true;
                        if_subscribe.Enabled = false;
                        sps_subscribe.Enabled = false;
                        if_send.Enabled = false;
                        sps_send.Enabled = false;
                        messagebox.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false; //close the connection
                }
           
            }
        }
        // event handler for if send button
        private void if_send_Click(object sender, EventArgs e)
        {

            string message = messagebox.Text;
            string usernameMessage = username1 + "," + message + "," + "IFmessage";
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(usernameMessage);
                clientSocket.Send(buffer);
            }

        }
        // event handler for sps send button
        private void sps_send_Click(object sender, EventArgs e)
        {
            string message = messagebox.Text;
            string usernameMessage = username1 + "," + message + "," + "SPSmessage";
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(usernameMessage);
                clientSocket.Send(buffer);
            }
        }
        //disconnect button handler
        private void button1_Click(object sender, EventArgs e)
        {
            actions.AppendText("You have disconnected.");
            actions.AppendText("\n");
            connect.Enabled = true;
            connected = false;
            terminating = true;
            Disconnect.Enabled = false;
            connect.Enabled = true;
            if_subscribe.Enabled = false;
            sps_subscribe.Enabled = false;
            if_send.Enabled = false;
            sps_send.Enabled = false;
            messagebox.Enabled = false;
            clientSocket.Close();
            connected = false;
            sps_subscribe.Text = "subscribe";
            if_subscribe.Text = "subscribe";
        
            
        }
    }
}
