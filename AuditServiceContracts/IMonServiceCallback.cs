using System.ServiceModel;

namespace AuditServiceContracts
{
	/// <summary>
	/// Callback сервиса
	/// </summary>
	[ServiceContract]
	public interface IMonServiceCallback
	{
		/// <summary>
		/// Ответ на запрос о получении перечня журналов событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void ResponseEventLogs(ResponseEventLogsDto dto);

		/// <summary>
		/// Ответ на запрос о получении записей журнала событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void ResponseEventLogEntities(ResponseEventLogEntriesDto dto);

		/// <summary>
		/// Оповестить о записи в журнале событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyEventLogEntryWritten(NotifyEventLogEntriesWrittenDto dto);

		/// <summary>
		/// Оповестить об изменении в файловой системе
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyFileWatcherEvent(NotifyFileWatcherEventDto dto);

		/// <summary>
		/// Оповестить об изменении состояния мониторинга журнала событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyEventMonitoringState(NotifyMonitoringStateDto dto);

		/// <summary>
		/// Оповестить об изменении состояния мониторинга файловой системы
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyFileWatcherState(NotifyMonitoringStateDto dto);

		/// <summary>
		/// Оповестить об изменении состояния мониторинга устройств
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyDeviceMonitoringState(NotifyMonitoringStateDto dto);

		/// <summary>
		/// Оповестить о событии мониторинга устройств
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void NotifyDeviceEvent(NotifyDeviceEventDto dto);
	}
}
