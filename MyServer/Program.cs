using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient receiver = new UdpClient(8080);
            IPEndPoint remoteIp = null;
            Console.WriteLine("Start Server");

            Picture();

            while (true)
            {
                
                byte[] data = receiver.Receive(ref remoteIp);
                if (Encoding.Unicode.GetString(data) == "Send me a date")
                {
                    IPEndPoint ip = remoteIp as IPEndPoint;
                    data = Encoding.Unicode.GetBytes(DateTime.Now.ToString());
                    receiver.Send(data, data.Length, ip.Address.ToString(), ip.Port);
                }
            }
        }

        private static void Picture()
        {
            Graphics graph = null;
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            graph = Graphics.FromImage(bmp);

            graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            bmp.Save("filename.png");
        }
    }
}
