using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            newsock.Bind(ipep);
            Console.WriteLine("Waiting for a client...");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);
            recv = newsock.ReceiveFrom(data, ref remote);
            Console.WriteLine("Message received from {0}:", remote.ToString());
            while(true)
            {
                data = new byte[1024];
                recv = newsock.ReceiveFrom(data, ref remote);
                string kq = Encoding.ASCII.GetString(data, 0, recv);
                if (kq == "1") Console.WriteLine("{0} chon bua", remote.ToString());
                if (kq == "2") Console.WriteLine("{0} chon keo", remote.ToString());
                if (kq == "3") Console.WriteLine("{0} chon bao", remote.ToString());
                int n = rd.Next(1, 4);
                if (n == 1) Console.WriteLine("Ban chon Bua");
                if (n == 2) Console.WriteLine("Ban chon Keo");
                if (n == 3) Console.WriteLine("Ban chon Bao");
                newsock.SendTo(Encoding.ASCII.GetBytes(n.ToString()), recv, SocketFlags.None, remote);
            }
        }
    }
}
