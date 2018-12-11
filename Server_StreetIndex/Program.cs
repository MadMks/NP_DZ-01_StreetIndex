using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_StreetIndex
{
    class Program
    {
        static int port = 8000;

        static void Main(string[] args)
        {

            Socket socketServer = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);


            try
            {
                // Связываем сокет с локальной точкой,
                // по которой будем принимать данные.
                socketServer.Bind(ipEndPoint);

                // Начинаем прослушивание.
                socketServer.Listen(10);

                Console.WriteLine("\nСервер запущен.\n");


                while (true)
                {
                    Socket socketClient = socketServer.Accept();


                    Console.WriteLine("Client endPoint: " +
                        socketClient.RemoteEndPoint.ToString());
                    Console.WriteLine("socketClient.ReceiveBufferSize: " 
                        + socketClient.ReceiveBufferSize.ToString());
                    Console.WriteLine("socketClient.Available: "
                        + socketClient.Available.ToString());
                    // Получаем сообщение.
                    StringBuilder stringBuilder = new StringBuilder();
                    int bytes = 0;  // Кол-во полученных байт.
                    // Буфер для получаемых данных.
                    byte[] data = new byte[socketClient.ReceiveBufferSize];

                    do
                    {
                        // TODO

                    } while (socketClient.Available > 0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n[error] " + ex.Message);
            }


        }
    }
}
