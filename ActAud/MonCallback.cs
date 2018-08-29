using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuditServiceContracts;

namespace ActAud
{
	/// <summary>
	/// Аргументы события, связанного с dto
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DtoEventArgs<T> : EventArgs
	{
		public DtoEventArgs(T dto)
		{
			_dto = dto;
		}

		private readonly T _dto;
		/// <summary>
		/// Dto
		/// </summary>
		public T Dto
		{
			get { return _dto; }
		}
	}

	/// <summary>
	/// Callback сервиса
	/// </summary>
	public class MonCallback : IMonServiceCallback
	{
		public void ResponseEventLogs(ResponseEventLogsDto dto)
		{
			EventLogsResponse(this, new DtoEventArgs<ResponseEventLogsDto>(dto));
		}

		/// <summary>
		/// Событие получения ответа на запрос перечня журналов событий
		/// </summary>
		public event EventHandler<DtoEventArgs<ResponseEventLogsDto>> EventLogsResponse = delegate { };

		/// <summary>
		/// Ответ на запрос о получении записей журнала событий
		/// </summary>
		public void ResponseEventLogEntities(ResponseEventLogEntriesDto dto)
		{
			EventLogEntriesResponse(this, new DtoEventArgs<ResponseEventLogEntriesDto>(dto));
		}

		/// <summary>
		/// Событие получения ответа на запрос о получении записей журнала событий
		/// </summary>
		public event EventHandler<DtoEventArgs<ResponseEventLogEntriesDto>> EventLogEntriesResponse = delegate { };

		/// <summary>
		/// Оповестить о записи в журнале событий
		/// </summary>
		public void NotifyEventLogEntryWritten(NotifyEventLogEntriesWrittenDto dto)
		{
			EventLogEntriesWrittenNotify(this, new DtoEventArgs<NotifyEventLogEntriesWrittenDto>(dto));
		}

		/// <summary>
		/// Событие оповещения о записи в журнале событий
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyEventLogEntriesWrittenDto>> EventLogEntriesWrittenNotify = delegate { };

		/// <summary>
		/// Оповестить об изменении в файловой системе
		/// </summary>
		public void NotifyFileWatcherEvent(NotifyFileWatcherEventDto dto)
		{
			FileWatcherEventNotify(this, new DtoEventArgs<NotifyFileWatcherEventDto>(dto));
		}

		/// <summary>
		/// Событие оповещения об изменении в файловой системе
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyFileWatcherEventDto>> FileWatcherEventNotify = delegate { };

		/// <summary>
		/// Оповестить об изменении состояния мониторинга журнала событий
		/// </summary>
		public void NotifyEventMonitoringState(NotifyMonitoringStateDto dto)
		{
			EventMonitoringStateNotify(this, new DtoEventArgs<NotifyMonitoringStateDto>(dto));
		}

		/// <summary>
		/// Событие оповещения об изменении состояния мониторинга журнала событий
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyMonitoringStateDto>> EventMonitoringStateNotify = delegate { };

		/// <summary>
		/// Оповестить об изменении состояния мониторинга файловой системы
		/// </summary>
		public void NotifyFileWatcherState(NotifyMonitoringStateDto dto)
		{
			FileWatcherStateNotify(this, new DtoEventArgs<NotifyMonitoringStateDto>(dto));
		}

		/// <summary>
		/// Событие оповещения об изменении состояния мониторинга файловой системы
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyMonitoringStateDto>> FileWatcherStateNotify = delegate { };

		/// <summary>
		/// Оповестить об изменении состояния мониторинга устройств
		/// </summary>
		public void NotifyDeviceMonitoringState(NotifyMonitoringStateDto dto)
		{
			DeviceMonitoringStateNotify(this, new DtoEventArgs<NotifyMonitoringStateDto>(dto));
		}

		/// <summary>
		/// Событие оповещения об изменении состояния мониторинга устройств
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyMonitoringStateDto>> DeviceMonitoringStateNotify = delegate { };

		/// <summary>
		/// Оповестить о событии мониторинга устройств
		/// </summary>
		public void NotifyDeviceEvent(NotifyDeviceEventDto dto)
		{
			DeviceEventNotify(this, new DtoEventArgs<NotifyDeviceEventDto>(dto));
		}

		/// <summary>
		/// Событие оповещения о событии мониторинга устройств
		/// </summary>
		public event EventHandler<DtoEventArgs<NotifyDeviceEventDto>> DeviceEventNotify = delegate { };
	}
}
