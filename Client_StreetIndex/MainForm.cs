using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
                // Посылаем запрос (почтовый индекс).
                strPostCode = textBoxPostCode.Text;
                clientSocket.Send(Encoding.Unicode.GetBytes(strPostCode));

                // Переменные для ответа.   // TODO упростить как на сервере.
                byte[] buffer = new byte[100];
                int bytes = 0;
                //StringBuilder temp = new StringBuilder();
                List<string> streets = null;

                // Получаем ответ.
                //bytes = clientSocket.Receive(
                //    buffer, buffer.Length, SocketFlags.None
                //    );
                //streets = ByteArrayToListString(buffer);


                if (streets != null)
                {
                    // Заносим данные в listbox
                    //this.listBoxStreets.DataSource = streets;
                }
                List<byte> listBytes = new List<byte>();
                do
                {
                    bytes = clientSocket.Receive(
                        buffer,
                        buffer.Length,
                        SocketFlags.None);
                    listBytes.AddRange(buffer);
                    //temp.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                    //Array.Clear(buffer, 0, buffer.Length);
                } while (clientSocket.Available > 0);

                //this.listBoxStreets.Items.Add(temp);
            }


            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();
        }

        private List<string> ByteArrayToListString(byte[] buffer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                memoryStream.Write(buffer, 0, buffer.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                object obj = formatter.Deserialize(memoryStream);
                return obj as List<string>;
            }
        }
    }
}
