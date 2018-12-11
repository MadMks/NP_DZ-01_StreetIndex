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

        Socket socket = null;

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
            this.socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);

            socket.Connect(ipEndPoint);

            if (socket.Connected)
            {
                strPostCode = textBoxPostCode.Text;
                socket.Send(Encoding.Unicode.GetBytes(strPostCode));
            }

            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();
        }
    }
}
