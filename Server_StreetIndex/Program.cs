using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Server_StreetIndex
{
    class Program
    {
        static readonly int SLEEP_TIME_THREAD = 5; // for debugging.

        const int port = 8000;
        const string ip = "127.0.0.1";
        const string pathFile = "data.xml";

        static List<string> streets = null;

        static void Main(string[] args)
        {
            Socket socketServer = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);

            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);


            try
            {
                // Связываем сокет с локальной точкой,
                // по которой будем принимать данные.
                socketServer.Bind(ipEndPoint);

                // Начинаем прослушивание.
                socketServer.Listen(10);

                Console.WriteLine("\n Сервер запущен.\n");


                while (true)
                {
                    Socket socketClient = socketServer.Accept();

                    // Получаем сообщение.
                    StringBuilder stringBuilder = new StringBuilder();
                    int bytes = 0;  // Кол-во полученных байт.
                    // Буфер для получаемых данных.
                    byte[] buffer = new byte[10];

                    // Загрузка получаемого сообщения.
                    bytes = socketClient.Receive(buffer);
                    stringBuilder.Append(
                        Encoding.Unicode.GetString(buffer, 0, bytes));

                    // Вывод на сервере
                    Console.WriteLine("\n[query] -> post code: " 
                        + stringBuilder
                        + "\n");


                    // ----------------


                    // Поиск почтового индекса в файле xml
                    streets = SearchStreetByCode(
                        Int32.Parse(stringBuilder.ToString())
                        );
                    // если такой есть -> вернуть список улиц.
                    if (streets != null)
                    {
                        //LongBootSimulation();     // For DEBUG

                        Console.WriteLine("[info] -> Улицы найдены!");

                        // Отправка ответа.
                        buffer = ObjectToByteArray(streets);
                        socketClient.Send(buffer);

                        Console.WriteLine("\n[info] -> Ответ отправлен buffer = "
                            + buffer.Length
                            + "\n");
                    }


                    // Закрываем сокет.
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n[error] " + ex.Message);

                Console.ReadKey();
            }


        }


        /// <summary>
        /// Иммитация долгой загрузки.
        /// </summary>
        private static void LongBootSimulation()
        {
            for (int i = 0; i < SLEEP_TIME_THREAD; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"[time]: {i + 1} (s)");
            }
        }


        /// <summary>
        /// Поиск улиц по почтовому индексу.
        /// </summary>
        /// <param name="postCode">Почтовый индекс.</param>
        /// <returns>Список улиц.</returns>
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
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            streets.Add(node.ChildNodes[i].InnerText);
                        }

                        return streets;
                    }

                    Console.WriteLine("[search] ...");
                }
            }
            else
            {
                Console.WriteLine("\n [error] " +
                    "Файл не найден -> " + pathFile);
            }

            return null;
        }

        /// <summary>
        /// Конвертирование объекта в массив байтов.
        /// </summary>
        /// <param name="obj">Объект для конвертирования.</param>
        /// <returns>Массив байтов.</returns>
        static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, obj);

                return memoryStream.ToArray();
            }
        }

    }
}
