using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

using AuditServiceContracts;

namespace ActAud
{
	/// <summary>
	/// Сервер
	/// </summary>
	public class MonServer : MonCallback, IDisposable
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="ip">Ip-адрес</param>
		/// <param name="monService">Сервис</param>
		/// <param name="callback">callback</param>
		public MonServer(IPAddress ip)
		{
			_ip = ip;
		}

		/// <summary>
		/// Сервис
		/// </summary>
		private IMonService _monService;

		private string _serverName;
		/// <summary>
		/// Имя сервера
		/// </summary>
		public string ServerName
		{
			get { return _serverName; }
		}

		private readonly IPAddress _ip;
		/// <summary>
		/// Ip-адрес
		/// </summary>
		public IPAddress IPaddr
		{
			get { return _ip; }
		}

		/// <summary>
		/// Инициализация
		/// </summary>
		public void Initialize()
		{
			Uri address = new Uri(string.Format("net.tcp://{0}:41993/IMonService/", _ip.ToString()));
			NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
			binding.SendTimeout = Constants.SendTimeout;
			binding.ReceiveTimeout = Constants.ReceiveTimeout;
			binding.OpenTimeout = Constants.OpenTimeout;
			binding.CloseTimeout = Constants.CloseTimeout;
			binding.MaxBufferSize = Constants.MaxBufferSize;
			binding.MaxReceivedMessageSize = Constants.MaxReceivedMessageSize;
			binding.MaxBufferPoolSize = Constants.MaxBufferPoolSize;

			EndpointAddress monEndpoint = new EndpointAddress(address); 
			
			ChannelFactory<IMonService> monFactory = new DuplexChannelFactory<IMonService>(new InstanceContext(this), binding, monEndpoint);
			_monService = monFactory.CreateChannel();
			((ICommunicationObject)(_monService)).Faulted += OnMonServerFaulted;
		}

		/// <summary>
		/// Событие обрыва соединения
		/// </summary>
		private void OnMonServerFaulted(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format("### Channel Faulted {0}", _ip));
		}

		/// <summary>
		/// Проверка соединения
		/// </summary>
		public bool TestConnection()
		{
			bool res = _monService.TestConnection();
			if (res)
			{
				//Получаем имя сервера при успешном соединении
				_serverName = _monService.GetServerName();
			}
			return res;
		}

		/// <summary>
		/// Подключиться
		/// </summary>
		/// <returns>Сообщение об ошибке</returns>
		public string Connect()
		{
			return _monService.Connect();
		}

		/// <summary>
		/// Отключиться
		/// </summary>
		public void Disconnect()
		{
			_monService.Disconnect();
		}

		/// <summary>
		/// Запросить перечень журналов событий
		/// </summary>
		public void RequestEventLogs()
		{
			_monService.RequestEventLogs(new RequestEventLogsDto());
		}

		/// <summary>
		/// Запросить записи журнала событий
		/// </summary>
		/// <param name="log">Журнал</param>
		/// <param name="filter">Фильтра</param>
		public void RequestEventLogEntries(string log, EventLogEntryFilter filter)
		{
			_monService.RequestEventLogEntries(new RequestEventLogEntriesDto() { Log = log, Filter = filter });
		}

		/// <summary>
		/// Запустить мониторинг событий
		/// </summary>
		public void StartEventMonitoring()
		{
			_monService.StartEventMonitoring();
		}

		/// <summary>
		/// Остановить мониторинг событий
		/// </summary>
		public void StopEventMonitoring()
		{
			_monService.StopEventMonitoring();
		}

		/// <summary>
		/// Запустить мониторинг файловой системы
		/// </summary>
		public void StartFileWatcher(string path, FileEventType type)
		{
			_monService.StartFileWatcher(new FileWatcherSettingsDto() { Path = path, EventType = type });
		}

		/// <summary>
		/// Остановить мониторинг файловой системы
		/// </summary>
		public void StopFileWatcher()
		{
			_monService.StopFileWatcher();
		}

		/// <summary>
		/// Запустить мониторинг устройств
		/// </summary>
		public void StartDeviceMonitoring()
		{
			_monService.StartDeviceMonitoring();
		}

		/// <summary>
		/// Остановить мониторинг устройств
		/// </summary>
		public void StopDeviceMonitoring()
		{
			_monService.StopDeviceMonitoring();
		}

		/// <summary>
		/// Уничтожение объекта
		/// </summary>
		public void Dispose()
		{
			if(_monService != null)
				((ICommunicationObject)(_monService)).Faulted -= OnMonServerFaulted;
		}
	}
}
