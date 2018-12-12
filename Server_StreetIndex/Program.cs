using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server_StreetIndex
{
    class Program
    {
        static int port = 8000;
        static string pathFile = "data.xml";

        static List<string> streets = null;

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
                    byte[] buffer = new byte[socketClient.Available];

                    // Загрузка получаемого сообщения.
                    bytes = socketClient.Receive(buffer);
                    stringBuilder.Append(
                        Encoding.Unicode.GetString(buffer, 0, bytes));
                    //do
                    //{
                    //    // Получаем данные.
                    //    bytes += socketClient.Receive(
                    //        buffer, 
                    //        buffer.Length, 
                    //        SocketFlags.None);
                    //    stringBuilder.Append(
                    //        Encoding.Unicode.GetString(buffer, 0, bytes));

                    //} while (socketClient.Available > 0);

                    
                    // TEMP вывод на сервере
                    Console.WriteLine("[test] -> post code: " + stringBuilder);


                    // Отправка ответа.

                    // Поиск почтового индекса в файле xml
                    streets = SearchStreetByCode(
                        Int32.Parse(stringBuilder.ToString())
                        );
                    // если такой есть -> вернуть список улиц.
                    if (streets != null)
                    {
                        Console.WriteLine("Улицы найдены!");
                        //Console.ReadKey();
                        buffer = ObjectToByteArray(streets);
                        socketClient.Send(buffer);

                        Console.WriteLine(" Ответ отправлен buffer = "
                            + buffer.Length);
                    }


                    //string temp = "test " + stringBuilder;
                    //buffer = Encoding.Unicode.GetBytes(temp);
                    //socketClient.Send(buffer);

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

        static List<string> SearchStreetByCode(int postCode)
        {
            List<string> streets = new List<string>();

            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists(pathFile))
            {
                xmlDocument.Load(pathFile);

                foreach (XmlNode node in xmlDocument.DocumentElement)
                {
                    if (postCode == Int32.Parse(node.Attributes[0].Value))
                    {
                        //streets.AddRange(node.ChildNodes as IEnumerable<string>);
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            streets.Add(node.ChildNodes[i].InnerText);
                        }

                        return streets;
                    }

                    Console.WriteLine("поиск ...");
                }
            }
            else
            {
                Console.WriteLine("\n [error] " +
                    "Файл не найден -> " + pathFile);
            }

            return null;
        }

        // Конвертирование объекта в массив байтов.
        static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, obj);

                return memoryStream.ToArray();
            }
        }

        //static List<string> LoadingDataFromXML()
        //{

        //}
    }
}
