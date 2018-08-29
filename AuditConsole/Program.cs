using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

using AuditServiceContracts;

namespace AuditConsole
{
    class Program
    {
        static ServiceHost host = null;
		static byte[] _ip;
        static CNetworkCardDesc NetworkCardForServerDesc = null;
        //[DllImport("user32.dll")]
        //private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //[DllImport("kernel32.dll", ExactSpelling = true)]
        //private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            foreach (NetworkInterface NetInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (NetInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                    NetInterface.NetworkInterfaceType == NetworkInterfaceType.FastEthernetT ||
                    NetInterface.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet ||
                    NetInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    NetworkCardForServerDesc = new CNetworkCardDesc(NetInterface);
                }
            }
            _ip = NetworkCardForServerDesc.CardIPAddress.GetAddressBytes();

            CreateServiceHost();
            //ShowWindow(GetConsoleWindow(), 1); // Скрыть.
            //ShowWindow(GetConsoleWindow(), 0); // Показать.
            //var icon = new NotifyIcon();
            //icon.Icon = new Icon("icon.ico");
            //icon.Visible = true;
            Console.ReadLine();
        }
        

        static void CreateServiceHost()
        {
            try
            {
                byte[] addr = NetworkCardForServerDesc.CardIPAddress.GetAddressBytes();
                string ipAddr = addr[0] + "." + addr[1] + "." + addr[2] + "." + addr[3];
                Uri address = new Uri("net.tcp://" + ipAddr + ":41993/IMonService/");

				NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
				binding.SendTimeout = Constants.SendTimeout;
				binding.ReceiveTimeout = Constants.ReceiveTimeout;
				binding.OpenTimeout = Constants.OpenTimeout;
				binding.CloseTimeout = Constants.CloseTimeout;
				binding.MaxBufferSize = Constants.MaxBufferSize;
				binding.MaxReceivedMessageSize = Constants.MaxReceivedMessageSize;
				binding.MaxBufferPoolSize = Constants.MaxBufferPoolSize;

                Type contract = typeof(IMonService);

				host = new ServiceHost(new MonService(_ip));
				var metadataBehavior = new ServiceMetadataBehavior();
				host.Description.Behaviors.Add(metadataBehavior);
				host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                host.AddServiceEndpoint(contract, binding, address);

                host.Open();

                Console.WriteLine("Сервер запущен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CloseServiceHost()
        {
            try
            {
                if (host != null)
                {
                    host.Close();

                    Console.WriteLine("Сервер остановлен!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
