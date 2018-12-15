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
        const int port = 8000;
        const string ip = "127.0.0.1";

        IPAddress ipServer;
        IPEndPoint ipEndPoint;

        Socket clientSocket = null;


        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ipServer = IPAddress.Parse(ip);
            this.ipEndPoint = new IPEndPoint(ipServer, port);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string postCode = textBoxPostCode.Text;

            Task.Factory.StartNew( () => DataExchange(postCode));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="postCode"></param>
        private void DataExchange(string postCode)
        {
            try
            {
                this.clientSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);

                clientSocket.Connect(ipEndPoint);

                if (clientSocket.Connected)
                {
                    // Посылаем запрос (почтовый индекс).
                    clientSocket.Send(Encoding.Unicode.GetBytes(postCode));


                    ReceivingData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ReceivingData()
        {
            // Переменные для ответа.
            byte[] buffer = new byte[1024];
            int bytes = 0;
            List<string> streets = null;

            // Получаем ответ.
            List<byte> listBytes = new List<byte>();
            do
            {
                bytes = clientSocket.Receive(
                    buffer,
                    buffer.Length,
                    SocketFlags.None);

                listBytes.AddRange(buffer);

                //Array.Clear(buffer, 0, buffer.Length);
            } while (clientSocket.Available > 0);

            if (bytes > 0)
            {
                streets = ByteArrayToListString(listBytes.ToArray());
                
                this.listBoxStreets.Invoke(
                    new Action<List<string>>(this.OutputDataToListBox),
                    streets
                    );
            }
            else
            {
                MessageBox.Show("По данному индексу улиц нет.");
            }
        }

        private void OutputDataToListBox(List<string> streets)
        {
            if (streets != null)
            {
                // Заносим данные в listbox
                this.listBoxStreets.DataSource = streets;
            }
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
