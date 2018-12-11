using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_StreetIndex
{
    public partial class MainForm : Form
    {
        static int port = 8000;
        IPAddress ipServer;
        IPEndPoint ipEndPoint;

        Socket clientSocket = null;

        string strPostCode = null;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ipServer = IPAddress.Parse("127.0.0.1");
            this.ipEndPoint = new IPEndPoint(ipServer, port);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.clientSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);

            clientSocket.Connect(ipEndPoint);

            if (clientSocket.Connected)
            {
                strPostCode = textBoxPostCode.Text;
                clientSocket.Send(Encoding.Unicode.GetBytes(strPostCode));

                // для ответа
                byte[] buffer = new byte[1024];
                int bytes = 0;
                StringBuilder temp = new StringBuilder();

                do
                {
                    bytes = clientSocket.Receive(
                        buffer,
                        buffer.Length,
                        SocketFlags.None);

                    temp.Append(Encoding.Unicode.GetString(buffer, 0, bytes));

                } while (clientSocket.Available > 0);
                
                this.listBoxStreets.Items.Add(temp);
            }


            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();
        }
    }
}
