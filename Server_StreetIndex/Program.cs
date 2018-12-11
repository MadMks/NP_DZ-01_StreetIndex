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

                    // Получаем сообщение.
                    StringBuilder stringBuilder = new StringBuilder();
                    int bytes = 0;  // Кол-во полученных байт.
                    // Буфер для получаемых данных.
                    byte[] buffer = new byte[1024];

                    
                    do
                    {
                        // Получаем данные.
                        bytes += socketClient.Receive(
                            buffer, 
                            buffer.Length, 
                            SocketFlags.None);
                        stringBuilder.Append(
                            Encoding.Unicode.GetString(buffer, 0, bytes));

                    } while (socketClient.Available > 0);

                    
                    // TEMP вывод на сервере
                    Console.WriteLine("[test] -> post code: " + stringBuilder);


                    // TODO отправить ответ
                    // поиск почтового индекса в файле xml
                    // если такой есть -> вернуть список улиц.
                    string temp = "test " + stringBuilder;
                    buffer = Encoding.Unicode.GetBytes(temp);
                    socketClient.Send(buffer);

                    // Закрываем сокет.
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n[error] " + ex.Message);
            }


        }
    }
}
