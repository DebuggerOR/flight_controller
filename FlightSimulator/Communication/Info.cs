using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FlightSimulator.Communication
{
    class Info
    {
		private TcpClient client;
        private TcpListener listener;
        private BinaryReader reader;
        
        public void Connect(int port)
        {
		    this.listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
		    this.listener.Start();
			this.client = this.listener.AcceptTcpClient();
            this.reader = new BinaryReader(client.GetStream());
        }

        public double[] Read()
        {
            try
            {
			    // get input until \n
			    string input = "";
                char c = this.reader.ReadChar();
			    while (c != '\n')
			    {
			    	input += c;
			    	c = this.reader.ReadChar();
			    }
			    
			    // return lon and lat
			    string[] parsed = input.Split(',');
                return new[] { Convert.ToDouble(parsed[0]), Convert.ToDouble(parsed[1]) };
            }
            catch {}
            return new[] {0.0, 0.0};
        }

        // singleton
        private static Info m_Instance = null;
        public static Info Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Info();
                }
                return m_Instance;
            }
        }
    }
}
