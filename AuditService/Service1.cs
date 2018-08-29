using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AuditServiceContracts;
using System.ServiceModel.Description;

namespace AuditService
{
    public partial class Service1 : ServiceBase
    {
        static ServiceHost host = null;
        static byte[] _ip;
        static CNetworkCardDesc NetworkCardForServerDesc = null;
        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "AuditService";
            this.CanStop = true; // службу можно остановить
            this.CanPauseAndContinue = true; // службу можно приостановить и затем продолжить
            this.AutoLog = true; // служба может вести запись в лог
        }

        protected override void OnStart(string[] args)
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
        }

        protected override void OnStop()
        {
            CloseServiceHost();
        }

        void CreateServiceHost()
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

        void CloseServiceHost()
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
