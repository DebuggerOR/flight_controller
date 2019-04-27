using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulator.Communication
{
    class Commands
    {
        private TcpClient client;
        private BinaryWriter writer;

        public void Connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            this.client = new TcpClient();
            while (!client.Connected)
            {
                try
                {
                    this.client.Connect(ep);
                    this.writer = new BinaryWriter(client.GetStream());
                }
                catch { }
            }
        }
       
        public void SendCommands(string input)
        {
            if(this.writer != null)
            {
                string[] commands = input.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    
                foreach (string command in commands)
                {
                    // send command with new line at end and wait 2 seconds
                    this.writer.Write(System.Text.Encoding.ASCII.GetBytes(command + "\r\n"));
                    Thread.Sleep(2000);
                }
            }
        }

		// singleton
        private static Commands m_Instance = null;
        public static Commands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Commands();
                }
                return m_Instance;
            }
        }
    }
}
