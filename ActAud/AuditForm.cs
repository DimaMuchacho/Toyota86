using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AuditServiceContracts;

namespace ActAud
{
	public partial class AuditForm : Form
	{
		public AuditForm(MonServer server)
		{
			InitializeComponent();
			foreach (var type in Enum.GetNames(typeof(EventLogEntryTypeFilter)))
			{
				EventTypeFilterComboBox.Items.Add(type);
			}
			FromFilterDatePicker.Value = DateTime.Now.Date;
			ToFilterDatePicker.Value = DateTime.Now.Date.AddDays(1);
			_server = server;
		}

		/// <summary>
		/// Сервер (stop)
		/// </summary>
		private readonly MonServer _server;

		/// <summary>
		/// Обработчик загрузки формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAuditFormLoad(object sender, EventArgs e)
		{
			var msg = _server.Connect();
			if (msg != null)
			{
				MessageBox.Show(msg, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			//Подписываемся на события на сервере
			_server.EventLogsResponse += OnServerEventLogsResponse;
			_server.EventLogEntriesResponse += OnServerEventLogEntriesResponse;
			_server.EventLogEntriesWrittenNotify += OnServerEventLogEntriesWrittenNotify;
			_server.FileWatcherEventNotify += OnServerFileWatcherEventNotify;
			_server.EventMonitoringStateNotify += OnServerEventMonitoringStateNotify;
			_server.FileWatcherStateNotify += OnServerFileWatcherStateNotify;
			_server.DeviceMonitoringStateNotify += OnServerDeviceMonitoringStateNotify;
			_server.DeviceEventNotify += OnServerDeviceEventNotify;

			_server.RequestEventLogs();
			_server.StartDeviceMonitoring();
		}

		/// <summary>
		/// Обработчик закрытия формы
		/// </summary>
		private void OnAuditFormFormClosed(object sender, FormClosedEventArgs e)
		{
			//Отключаемся от сервера
			_server.Disconnect();
			//Отписываемся от событий на сервере
			_server.EventLogsResponse -= OnServerEventLogsResponse;
			_server.EventLogEntriesResponse -= OnServerEventLogEntriesResponse;
			_server.EventLogEntriesWrittenNotify -= OnServerEventLogEntriesWrittenNotify;
			_server.FileWatcherEventNotify -= OnServerFileWatcherEventNotify;
			_server.EventMonitoringStateNotify -= OnServerEventMonitoringStateNotify;
			_server.FileWatcherStateNotify -= OnServerFileWatcherStateNotify;
			_server.DeviceMonitoringStateNotify -= OnServerDeviceMonitoringStateNotify;
			_server.DeviceEventNotify -= OnServerDeviceEventNotify;
		}

		/// <summary>
		/// Обработчик события получения записей журнала событий
		/// </summary>
		private void OnServerEventLogEntriesResponse(object sender, DtoEventArgs<ResponseEventLogEntriesDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					gbCurrentLog.Enabled = true;
					if (e.Dto.ErrorMessage != null)
					{
						MessageBox.Show(e.Dto.ErrorMessage, "Ошибка запроса записей журнала событий", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					CurrentLogDataGrid.Rows.Clear();
					if (e.Dto.LogEntries.Count == 0)
					{
						MessageBox.Show("В журнале не найдено записей");
					}
					foreach (var entry in e.Dto.LogEntries)
					{
						CurrentLogDataGrid.Rows.Add(entry.InstanceId, entry.EntryType.ToString(),
							entry.TimeGenerated, entry.MachineName, entry.Message);
					}
				}));
		}

		/// <summary>
		/// Обработчик оповещения о записи в журнал событий
		/// </summary>
		private void OnServerEventLogEntriesWrittenNotify(object sender, DtoEventArgs<NotifyEventLogEntriesWrittenDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					if (e.Dto.ErrorMessage != null)
					{
						return;
					}
					var entry = e.Dto.Entry;
					if (e.Dto.Log == "Security")
					{
						rtbMonitoredEvents.AppendText("Запись в журнал " + ((EventLog)sender).LogDisplayName + " Время " + entry.TimeWritten + "Позиция " + entry.Index + "\r\n");
					}
					else if (e.Dto.Log == "System")
					{
						if ((EventLogEntryType)entry.EntryType == EventLogEntryType.Error || (EventLogEntryType)entry.EntryType == EventLogEntryType.Information)
						{
							if ((entry.InstanceId == 4) || (entry.InstanceId == 472) || (entry.InstanceId == 477) || (entry.InstanceId == 517) ||
									   (entry.InstanceId == 624) || (entry.InstanceId == 535) || (entry.InstanceId == 533) || (entry.InstanceId == 529) ||
									   (entry.InstanceId == 632) || (entry.InstanceId == 539) || (entry.InstanceId == 534) || (entry.InstanceId == 531) ||
									   (entry.InstanceId == 636) || (entry.InstanceId == 660) || (entry.InstanceId == 6806) || (entry.InstanceId == 4645) ||
									   (entry.InstanceId == 642) || (entry.InstanceId == 675) || (entry.InstanceId == 681) || (entry.InstanceId == 4728) ||
									   (entry.InstanceId == 644) || (entry.InstanceId == 676) || (entry.InstanceId == 1102) || (entry.InstanceId == 4732) ||
									   (entry.InstanceId == 4740) || (entry.InstanceId == 4756) || (entry.InstanceId == 4768) || (entry.InstanceId == 4776) ||
									   (entry.InstanceId == 4738) || (entry.InstanceId == 4733) || (entry.InstanceId == 630) || (entry.InstanceId == 200) ||
									   (entry.InstanceId == 4124) || (entry.InstanceId == 4226) || (entry.InstanceId == 7901) ||
									   (entry.InstanceId == 12294) || (entry.InstanceId == 9095) || (entry.InstanceId == 9097) || (entry.InstanceId == 7023) ||
									   (entry.InstanceId == 6183) || (entry.InstanceId == 55) || (entry.InstanceId == 1066) || (entry.InstanceId == 6008) ||
									   (entry.InstanceId == 861) || entry.InstanceId == 7035)
							{
								//MessageBox.Show("Внимание! В системе произошло событие   "+  entry.InstanceId+ ".  Просмотрите журнал событий для выяснения причин.", "Система активного аудита", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								DialogResult result;
								result = MessageBox.Show("Внимание!" + "\r\n" + "В системе произошло событие    " + entry.InstanceId + "\r\n" + "Время     " +
									entry.TimeGenerated.ToString() + "\r\n" + "Сообщение:  " + entry.Message + "\r\n" + "\r\n" + "  Просмотрите журнал событий для выяснения причин.", "Мониторинг событий ИБ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
					}
				}));
		}

		/// <summary>
		/// Обработчик получения списка журналов событий
		/// </summary>
		private void OnServerEventLogsResponse(object sender, DtoEventArgs<ResponseEventLogsDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					if (e.Dto.ErrorMessage != null)
					{
						MessageBox.Show(e.Dto.ErrorMessage, "Ошибка запроса журналов событий", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					EventLogsTreeView.Nodes.Clear();
					var infoNode = new TreeNode();
					infoNode.Text = "Список доступных журналов аудита";
					EventLogsTreeView.Nodes.Add(infoNode);
					foreach (var elog in e.Dto.EventLogs)
					{
						var node = new TreeNode(string.Format("{0} ({1})", elog.Name, elog.DisplayName)) { Tag = elog };
						infoNode.Nodes.Add(node);
					}
					infoNode.Expand();
				}));
		}

		/// <summary>
		/// Обработчик оповещения о событии в файловой системе
		/// </summary>
		private void OnServerFileWatcherEventNotify(object sender, DtoEventArgs<NotifyFileWatcherEventDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					rtbInformation.AppendText(string.Format("{0}: {1} - {2}{3}", e.Dto.Time, e.Dto.Entry.EventType, e.Dto.Entry.Message, Environment.NewLine));
				}));
		}

		/// <summary>
		/// Обработчик нажатия на кнопку обновления текущего журнала событий
		/// </summary>
		private void OnRefreshEventLogsButtonClick(object sender, EventArgs e)
		{
			_server.RequestEventLogs();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку очистки журнала событий
		/// </summary>
		private void OnEraseCurrentLogButtonClick(object sender, EventArgs e)
		{
			CurrentLogDataGrid.Rows.Clear();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку обновления журнала событий
		/// </summary>
		private void OnRefreshCurrentLogButtonClick(object sender, EventArgs e)
		{
			RequestEventEntries(false);
		}

		/// <summary>
		/// Обработчик нажатия на кнопку обновления журнала событий с фильтром
		/// </summary>
		private void OnRefreshCurrentLogWithFilterButtonClick(object sender, EventArgs e)
		{
			RequestEventEntries(true);
		}

		/// <summary>
		/// Запросить записи журнала событий
		/// </summary>
		/// <param name="applyFilter">Применить фильтр</param>
		private void RequestEventEntries(bool applyFilter)
		{
			var selected = EventLogsTreeView.SelectedNode;
			if (selected == null || !(selected.Tag is EventLogInfoDto))
				return;
			var log = (selected.Tag as EventLogInfoDto).Name;

			EventLogEntryFilter filter = null;
			if (applyFilter)
			{
				long instanceIdFilter = -1;
				long.TryParse(InstanceIdFilterTextBox.Text, out instanceIdFilter);
				EventLogEntryTypeFilter type = EventLogEntryTypeFilter.None;
				if (EventTypeFilterComboBox.SelectedItem != null)
					Enum.TryParse<EventLogEntryTypeFilter>(EventTypeFilterComboBox.SelectedItem.ToString(), out type);
				filter = new EventLogEntryFilter()
				{
					InstanceId = instanceIdFilter,
					EntryType = type,
					MachineName = MachineNameFilterTextBox.Text,
					TimeGeneratedFrom = FromFilterDatePicker.Checked ? FromFilterDatePicker.Value : DateTime.MinValue,
					TimeGeneratedTo = ToFilterDatePicker.Checked ? ToFilterDatePicker.Value : DateTime.MaxValue
				};
			}
			gbCurrentLog.Enabled = false;
			_server.RequestEventLogEntries(log, filter);
			return;
		}

		private MonitoringState _eventMonitoringState;
		/// <summary>
		/// Состояние мониторинга событий
		/// </summary>
		private MonitoringState EventMonitoringState
		{
			get { return _eventMonitoringState; }
			set
			{
				if (_eventMonitoringState == value)
					return;
				_eventMonitoringState = value;
				StartEventMonitoringButton.Text = EventMonitoringState == MonitoringState.Started ?
					"Остановить мониторинг событий" : "Запустить мониторинг событий";
			}
		}

		/// <summary>
		/// Обработчик нажатия на кнопку запуска мониторинга событий
		/// </summary>
		private void OnStartEventMonitoringButtonClick(object sender, EventArgs e)
		{
			StartEventMonitoringButton.Enabled = false;
			if (EventMonitoringState != MonitoringState.Started)
			{
				_server.StartEventMonitoring();
			}
			else
			{
				_server.StopEventMonitoring();
			}
		}

		/// <summary>
		/// Обработчик изменения состояния мониторинга журнала событий
		/// </summary>
		private void OnServerEventMonitoringStateNotify(object sender, DtoEventArgs<NotifyMonitoringStateDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					EventMonitoringState = e.Dto.State;
					StartEventMonitoringButton.Enabled = true;
				}));
		}

		private MonitoringState _fileWatcherState;
		/// <summary>
		/// Состояние мониторинга файловой системы
		/// </summary>
		private MonitoringState FileWatcherState
		{
			get { return _fileWatcherState; }
			set
			{
				if (_fileWatcherState == value)
					return;
				_fileWatcherState = value;
				StartFileWatcherButton.Enabled = FileWatcherState != MonitoringState.Started;
				StopFileWatcherButton.Enabled = FileWatcherState == MonitoringState.Started;
			}
		}

		/// <summary>
		/// Обработчик изменения состояния мониторинга файловой системы
		/// </summary>
		private void OnServerFileWatcherStateNotify(object sender, DtoEventArgs<NotifyMonitoringStateDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					FileWatcherState = e.Dto.State;
				}));
		}

		/// <summary>
		/// Обработчик нажатия на кнопку запуска мониторинга файловой системы
		/// </summary>
		private void OnStartFileWatcherButtonClick(object sender, EventArgs e)
		{
			StartFileWatcherButton.Enabled = false;
			StopFileWatcherButton.Enabled = false;
			var type = FileEventType.None;
			if (clbActions.GetItemChecked(0)) type |= FileEventType.Changed;
			if (clbActions.GetItemChecked(1)) type |= FileEventType.Created;
			if (clbActions.GetItemChecked(2)) type |= FileEventType.Deleted;
			if (clbActions.GetItemChecked(3)) type |= FileEventType.Renamed;

			_server.StartFileWatcher(FileCatalogTextBox.Text, type);
		}

		/// <summary>
		/// Обработчик нажатия на кнопку остановки мониторинга файловой системы
		/// </summary>
		private void OnStopFileWatcherButtonClick(object sender, EventArgs e)
		{
			_server.StopFileWatcher();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку очистки журнала мониторинга файловой системы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClearFileWatcherButtonClick(object sender, EventArgs e)
		{
			rtbInformation.Clear();
		}

		/// <summary>
		/// Обработчик изменения состояния мониторинга устроств
		/// </summary>
		private void OnServerDeviceMonitoringStateNotify(object sender, DtoEventArgs<NotifyMonitoringStateDto> e)
		{
		}

		/// <summary>
		/// Обработчик события мониторинга устройств
		/// </summary>
		private void OnServerDeviceEventNotify(object sender, DtoEventArgs<NotifyDeviceEventDto> e)
		{
			BeginInvoke(new Action(() =>
				{
					if (!string.IsNullOrEmpty(e.Dto.Message))
					{
						lsbAuditDevices.Items.Add(e.Dto.Message);
						lsbAuditDevices.SelectedIndex = lsbAuditDevices.Items.Count - 1;
					}
				}));
		}
	}
}
