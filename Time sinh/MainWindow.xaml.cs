using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Time_sinh
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void SendClick(object sender, RoutedEventArgs e)
        {
            var s = await Task.Run(() => MyTimeParse());
            TimeLable.Content = s;
        }

        private string MyTimeParse()
        {

            UdpClient sender = new UdpClient();

            byte[] data = Encoding.Unicode.GetBytes("Send me a date");

            sender.Send(data, data.Length, "127.0.0.1", 8080);

            IPEndPoint remoteIp = null;
            data = sender.Receive(ref remoteIp);
            return Encoding.Unicode.GetString(data);
        }
    }
}

