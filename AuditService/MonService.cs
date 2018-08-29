using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;

using AuditServiceContracts;

namespace AuditService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class MonService : IMonService
	{
		private byte[] _serverIP;

		public MonService(byte[] serverIP)
		{
			_serverIP = serverIP;
		}

		/// <summary>
		/// Проверить подключение к серверу
		/// </summary>
		/// <returns>true, в случае доступности сервера для подключения</returns>
		public bool TestConnection()
		{
			Console.WriteLine("TestConnection");
			return true;
		}

		/// <summary>
		/// Подключиться
		/// </summary>
		/// <returns>Сообщение об ошибке или null, если соединение успешно</returns>
		public string Connect()
		{
			Console.WriteLine("Connect");
			string errorMessage = null;
			if (_subscriber != null)
			{
				errorMessage = "Подключение невозможно: к данному серверу уже подключен клиент";
			}
			else
			{
				_subscriber = GetCurrentCallBack();
			}
			return errorMessage;
		}

		/// <summary>
		/// Отключиться
		/// </summary>
		public void Disconnect()
		{
			Console.WriteLine("Disconnect");
			if(_subscriber == GetCurrentCallBack())
				_subscriber = null;
		}

		/// <summary>
		/// Получить имя сервера
		/// </summary>
		public string GetServerName()
		{
			Console.WriteLine("GetServerName");
			return Environment.MachineName;
		}

		#region EventLog

		/// <summary>
		/// Запрос на получение перечня журналов событий
		/// </summary>
		public async void RequestEventLogs(RequestEventLogsDto dto)
		{
			CancelEventLogsRequestTokenSource = new CancellationTokenSource();
			var callback = GetCurrentCallBack();
			Console.WriteLine(string.Format("RequestEventLogs {0}", dto.Id));
			var response = new ResponseEventLogsDto() { Id = dto.Id };
			try
			{
				response.EventLogs = await Task.Run(() => EventLog.GetEventLogs().Select(
						l => new EventLogInfoDto() { Name = l.Log, DisplayName = l.LogDisplayName }
					).ToList(), CancelEventLogsRequestTokenSource.Token);
			}
			catch (Exception ex)
			{
				response.ErrorMessage = ex.Message;
			}
			Console.WriteLine(string.Format("RequestEventLogs {0} Complete {1}", response.Id, response.ErrorMessage));
			if (!CancelEventLogsRequestTokenSource.IsCancellationRequested)
				Run(callback, c => c.ResponseEventLogs(response));
		}

		private CancellationTokenSource _cancelEventLogsRequestTokenSource;
		/// <summary>
		/// Источник токена для отмены получения перечня журналов событий
		/// </summary>
		private CancellationTokenSource CancelEventLogsRequestTokenSource
		{
			get { return _cancelEventLogsRequestTokenSource; }
			set
			{
				if (_cancelEventLogsRequestTokenSource == value)
					return;
				if (_cancelEventLogsRequestTokenSource != null)
				{
					_cancelEventLogsRequestTokenSource.Dispose();
				}
				_cancelEventLogsRequestTokenSource = value;
			}
		}

		/// <summary>
		/// Отменить получение перечня журналов событий
		/// </summary>
		/// <param name="id">Идентификатор журнала</param>
		public void CancelEventLogsRequest(long id)
		{
			Console.WriteLine(string.Format("CancelEventLogsRequest {0}", id));
			if (CancelEventLogsRequestTokenSource != null)
				CancelEventLogsRequestTokenSource.Cancel();
		}

		/// <summary>
		/// Получить записи журнала событий
		/// </summary>
		public async void RequestEventLogEntries(RequestEventLogEntriesDto dto)
		{
			CancelEventLogEntriesRequestTokenSource = new CancellationTokenSource();
			var callback = GetCurrentCallBack();
			Console.WriteLine(string.Format("RequestEventLogEntries {0}", dto.Id));
			var response = new ResponseEventLogEntriesDto() { Id = dto.Id };
			var cancelToken = CancelEventLogEntriesRequestTokenSource.Token;
			try
			{
				response.LogEntries = await Task.Run(() =>
						{
							var result = new List<EventLogEntryDto>();
							using (var logger = new EventLog(dto.Log))
							{
								foreach (var entry in logger.Entries.Cast<EventLogEntry>())
								{
									if (cancelToken.IsCancellationRequested)
										break;
									var filter = dto.Filter;
									if (filter != null)
									{
										if (filter.EntryType != EventLogEntryTypeFilter.None)
										{
											if ((int)entry.EntryType != (int)filter.EntryType)
												continue;
										}
										if (filter.InstanceId > 0)
										{
											if (entry.InstanceId != filter.InstanceId)
												continue;
										}
										if (!string.IsNullOrEmpty(filter.MachineName) && entry.MachineName != null)
										{
											if (!entry.MachineName.Contains(filter.MachineName))
												continue;
										}
										if (!string.IsNullOrEmpty(filter.MessagePart) && entry.Message != null)
										{
											if (!entry.Message.Contains(filter.MessagePart))
												continue;
										}
										if (filter.TimeGeneratedFrom > DateTime.MinValue || filter.TimeGeneratedTo < DateTime.MaxValue)
										{
											var min = filter.TimeGeneratedFrom < filter.TimeGeneratedTo
												? filter.TimeGeneratedFrom : filter.TimeGeneratedTo;
											var max = filter.TimeGeneratedTo > filter.TimeGeneratedFrom
												? filter.TimeGeneratedTo : filter.TimeGeneratedFrom;
											if (entry.TimeGenerated < min || entry.TimeGenerated > max)
												continue;
										}
									}
									var logEntry = new EventLogEntryDto()
									{
										EntryType = (EventLogEntryTypeFilter)entry.EntryType,
										InstanceId = entry.InstanceId,
										MachineName = entry.MachineName,
										Message = entry.Message,
										TimeGenerated = entry.TimeGenerated
									};
									result.Add(logEntry);
								}
							}
							return result;
						}, cancelToken
					);
			}
			catch (Exception ex)
			{
				response.ErrorMessage = ex.Message;
			}
			Console.WriteLine(string.Format("RequestEventLogEntries {0} Complete {1}", response.Id, response.ErrorMessage));
			if (!CancelEventLogEntriesRequestTokenSource.IsCancellationRequested)
				Run(callback, c => c.ResponseEventLogEntities(response));
		}

		private CancellationTokenSource _cancelEventLogEntriesRequestTokenSource;
		/// <summary>
		/// Источник токена для отмены получения перечня журналов событий
		/// </summary>
		private CancellationTokenSource CancelEventLogEntriesRequestTokenSource
		{
			get { return _cancelEventLogEntriesRequestTokenSource; }
			set
			{
				if (_cancelEventLogEntriesRequestTokenSource == value)
					return;
				if (_cancelEventLogEntriesRequestTokenSource != null)
				{
					_cancelEventLogEntriesRequestTokenSource.Dispose();
				}
				_cancelEventLogEntriesRequestTokenSource = value;
			}
		}

		/// <summary>
		/// Отменить получения записей журнала событий
		/// </summary>
		/// <param name="id">Идентификатор</param>
		public void CancelEventLogEntriesRequest(long id)
		{
			Console.WriteLine(string.Format("CancelEventLogEntriesRequest {0}", id));
			if (CancelEventLogEntriesRequestTokenSource != null)
				CancelEventLogEntriesRequestTokenSource.Cancel();
		}

		private EventLog _systemEventLog;
		/// <summary>
		/// Системный журнал событий
		/// </summary>
		private EventLog SystemEventLog
		{
			get { return _systemEventLog; }
			set
			{
				if (_systemEventLog == value)
					return;
				if (_systemEventLog != null)
				{
					_systemEventLog.EntryWritten -= OnSystemEventLogEntryWritten;
					_systemEventLog.Dispose();
				}
				_systemEventLog = value;
				if (_systemEventLog != null)
				{
					_systemEventLog.EntryWritten += OnSystemEventLogEntryWritten;
				}
			}
		}

		private EventLog _securityEventLog;
		/// <summary>
		/// Журнал событий безопасности
		/// </summary>
		private EventLog SecurityEventLog
		{
			get { return _securityEventLog; }
			set
			{
				if (_securityEventLog == value)
					return;
				if (_securityEventLog != null)
				{
					_securityEventLog.EntryWritten -= OnSecurityEventLogEntryWritten;
					_securityEventLog.Dispose();
				}
				_securityEventLog = value;
				if (_securityEventLog != null)
				{
					_securityEventLog.EntryWritten += OnSecurityEventLogEntryWritten;
				}
			}
		}

		/// <summary>
		/// Обработчик записи информации в системный журнал событий
		/// </summary>
		private void OnSystemEventLogEntryWritten(object sender, EntryWrittenEventArgs e)
		{
			NotifyEventLogEntryWritten("System", e.Entry);
		}

		/// <summary>
		/// Обработчик записи информации в журнал событий безопасности
		/// </summary>
		private void OnSecurityEventLogEntryWritten(object sender, EntryWrittenEventArgs e)
		{
			NotifyEventLogEntryWritten("Security", e.Entry);
		}

		/// <summary>
		/// Оповестить о появлении записи в журнале событий
		/// </summary>
		/// <param name="logName">Логгер</param>
		private void NotifyEventLogEntryWritten(string logName, EventLogEntry entry)
		{
			Run(_subscriber, s => s.NotifyEventLogEntryWritten(
					new NotifyEventLogEntriesWrittenDto()
					{
						Log = logName,
						Entry = new EventLogEntryDto()
						{
							InstanceId = entry.InstanceId,
							TimeWritten = entry.TimeWritten,
							Index = entry.Index,
							EntryType = (EventLogEntryTypeFilter)entry.EntryType,
							MachineName = entry.MachineName,
							Message = entry.Message,
							TimeGenerated = entry.TimeGenerated
						}
					}));
		}

		private MonitoringState _eventMonitoringState;
		/// <summary>
		/// Состояние мониторинга журнала событий
		/// </summary>
		public MonitoringState EventMonitoringState
		{
			get { return _eventMonitoringState; }
			set
			{
				if (_eventMonitoringState == value)
					return;
				_eventMonitoringState = value;
				Run(_subscriber, s => s.NotifyEventMonitoringState(new NotifyMonitoringStateDto() { State = EventMonitoringState }));
			}
		}

		/// <summary>
		/// Запустить мониторинг журнала событий
		/// </summary>
		public void StartEventMonitoring()
		{
			Console.WriteLine(string.Format("StartEventMonitoring"));
			SystemEventLog = new EventLog("System");
			SecurityEventLog = new EventLog("Security");
			EventMonitoringState = MonitoringState.Started;
		}

		/// <summary>
		/// Остановить мониторинг журнала событий
		/// </summary>
		public void StopEventMonitoring()
		{
			Console.WriteLine(string.Format("StopEventMonitoring"));
			SystemEventLog = null;
			SecurityEventLog = null;
			EventMonitoringState = MonitoringState.Stopped;
		}

		#endregion EventLog

		#region FileWatcher

		private FileSystemWatcher _watcher;
		/// <summary>
		/// Наблюдатель
		/// </summary>
		private FileSystemWatcher Watcher
		{
			get { return _watcher; }
			set
			{
				if (_watcher == value)
					return;
				if (_watcher != null)
				{
					_watcher.Changed -= OnFileChanged;
					_watcher.Created -= OnFileCreated;
					_watcher.Deleted -= OnFileDeleted;
					_watcher.Renamed -= OnFileRenamed;
					_watcher.Dispose();
				}
				_watcher = value;
			}
		}

		/// <summary>
		/// Обработчик переименования файла
		/// </summary>
		private void OnFileRenamed(object sender, RenamedEventArgs e)
		{
			NotifyFileWatcher(FileEventType.Renamed, string.Format("{0} => {1}", e.OldName, e.Name));
		}

		/// <summary>
		/// Обработчик удаления файла
		/// </summary>
		private void OnFileDeleted(object sender, FileSystemEventArgs e)
		{
			NotifyFileWatcher(FileEventType.Deleted, e.Name);
		}

		/// <summary>
		/// Обработчик создания файла
		/// </summary>
		private void OnFileCreated(object sender, FileSystemEventArgs e)
		{
			NotifyFileWatcher(FileEventType.Created, e.Name);
		}

		/// <summary>
		/// Обработчик изменения файла
		/// </summary>
		private void OnFileChanged(object sender, FileSystemEventArgs e)
		{
			NotifyFileWatcher(FileEventType.Changed, e.Name);
		}

		/// <summary>
		/// Оповестить об событии в файловой системе
		/// </summary>
		private void NotifyFileWatcher(FileEventType type, string message)
		{
			Run(_subscriber, s => s.NotifyFileWatcherEvent(
				new NotifyFileWatcherEventDto()
				{
					Entry = new FileWatcherLogEntryDto()
					{
						EventType = type,
						Message = message
					}
				}));
		}

		private MonitoringState _fileWatcherState;
		/// <summary>
		/// Состояние мониторинга журнала событий
		/// </summary>
		public MonitoringState FileWatcherState
		{
			get { return _fileWatcherState; }
			set
			{
				if (_fileWatcherState == value)
					return;
				_fileWatcherState = value;
				Run(_subscriber, s => s.NotifyFileWatcherState(new NotifyMonitoringStateDto() { State = FileWatcherState }));
			}
		}

		/// <summary>
		/// Запустить мониторинг директории
		/// </summary>
		public void StartFileWatcher(FileWatcherSettingsDto dto)
		{
			Console.WriteLine(string.Format("StartFileWatcher {0}", dto.Path));
			try
			{
				Watcher = new FileSystemWatcher(dto.Path, "*.*");
				Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
				if (dto.EventType.HasFlag(FileEventType.Changed))
				{
					_watcher.Changed -= OnFileChanged;
					_watcher.Changed += OnFileChanged;
				}
				if (dto.EventType.HasFlag(FileEventType.Created))
				{
					_watcher.Created -= OnFileCreated;
					_watcher.Created += OnFileCreated;
				}
				if (dto.EventType.HasFlag(FileEventType.Deleted))
				{
					_watcher.Deleted -= OnFileDeleted;
					_watcher.Deleted += OnFileDeleted;
				}
				if (dto.EventType.HasFlag(FileEventType.Renamed))
				{
					_watcher.Renamed -= OnFileRenamed;
					_watcher.Renamed += OnFileRenamed;
				}
				Watcher.EnableRaisingEvents = true;
				FileWatcherState = MonitoringState.Started;
			}
			catch(Exception ex)
			{
				Console.WriteLine(string.Format("Error: StartFileWatcher\r\n{0}", ex.Message));
				FileWatcherState = MonitoringState.Stopped;
			}
		}

		/// <summary>
		/// Остановить мониторинг директории
		/// </summary>
		public void StopFileWatcher()
		{
			Console.WriteLine("StopFileWatcher");
			Watcher = null;
			FileWatcherState = MonitoringState.Stopped;
		}

		#endregion FileWatcher

		#region Device



		private MonitoringState _deviceMonitoringState;
		/// <summary>
		/// Состояние мониторинга журнала событий
		/// </summary>
		public MonitoringState DeviceMonitoringState
		{
			get { return _deviceMonitoringState; }
			set
			{
				if (_deviceMonitoringState == value)
					return;
				_deviceMonitoringState = value;
				Run(_subscriber, s => s.NotifyDeviceMonitoringState(new NotifyMonitoringStateDto() { State = DeviceMonitoringState }));
			}
		}

		/// <summary>
		/// Запустить мониторинг устройств
		/// </summary>
		public void StartDeviceMonitoring()
		{
			Console.WriteLine("StartDeviceMonitoring");
			DeviceChangeNotifier.Start();
			DeviceChangeNotifier.LogReceived -= OnDeviceChangeNotifierLogReceived;
			DeviceChangeNotifier.LogReceived += OnDeviceChangeNotifierLogReceived;
			DeviceMonitoringState = MonitoringState.Started;
		}

		/// <summary>
		/// Обработчик события мониторинга устройств
		/// </summary>
		private void OnDeviceChangeNotifierLogReceived(object sender, EventArgs e)
		{
			var log = DeviceChangeNotifier.Log;
			DeviceChangeNotifier.Log = string.Empty;
			Run(_subscriber, s => s.NotifyDeviceEvent(
				new NotifyDeviceEventDto() { Message = log }
				));
		}

		/// <summary>
		/// Остановить мониторинг устройств
		/// </summary>
		public void StopDeviceMonitoring()
		{
			Console.WriteLine("StopDeviceMonitoring");
			DeviceChangeNotifier.LogReceived -= OnDeviceChangeNotifierLogReceived;
			DeviceChangeNotifier.Stop();
			DeviceMonitoringState = MonitoringState.Stopped;
		}

		#endregion Device

		#region Wcf

		/// <summary>
		/// Текущий подписчик
		/// </summary>
		private IMonServiceCallback _subscriber;

		/// <summary>
		/// Получить текущий callback
		/// </summary>
		/// <returns></returns>
		private IMonServiceCallback GetCurrentCallBack()
		{
			return OperationContext.Current.GetCallbackChannel<IMonServiceCallback>();
		}

		/// <summary>
		/// Проверка валидности подписчика
		/// </summary>
		/// <param name="subscriber"></param>
		/// <returns></returns>
		private bool IsValidSubscriber(object subscriber)
		{
			return ((IChannel)subscriber).State == CommunicationState.Opened;
		}


		private void Run(IMonServiceCallback obj, Action<IMonServiceCallback> action)
		{
			bool valid = IsValidSubscriber(obj);
			if (valid)
			{
				try
				{
					action(obj);
				}
				catch (CommunicationException ex)
				{
					Console.WriteLine(string.Format("При выполнении {0} произошла ошибка {1}",
						action.Method.Name, ex.Message));
					valid = false;
				}
			}
			if (!valid && (obj == _subscriber))
			{
				_subscriber = null;
			}
		}

		#endregion Wcf
	}
}
