using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace SimpleSocketServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sck.Bind(new IPEndPoint(0, 7070));    
            sck.Listen(0);

            Socket acc = sck.Accept();

            byte[] buffer = Encoding.Default.GetBytes("Eu te escutei cliente!");
            acc.Send(buffer, 0, buffer.Length, 0);

            buffer = new byte[255];

            int rec = acc.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);

            Console.WriteLine("Recebido: {0}", Encoding.Default.GetString(buffer));



            Console.Read();


            {


            }
        }
    }
}
