using System.Collections.Generic;
using System.ServiceModel;

namespace AuditServiceContracts
{
	/// <summary>
	/// Сервис
	/// </summary>
	[ServiceContract(CallbackContract = typeof(IMonServiceCallback), SessionMode = SessionMode.Required)]
	public interface IMonService
	{
		/// <summary>
		/// Проверить подключение к серверу
		/// </summary>
		/// <returns>true, в случае доступности сервера для подключения</returns>
		[OperationContract]
		bool TestConnection();

		/// <summary>
		/// Получить имя сервера
		/// </summary>
		[OperationContract]
		string GetServerName();

		/// <summary>
		/// Подключиться к серверу
		/// </summary>
		/// <returns>Сообщение об ошибке или null, если соединение успешно</returns>
		[OperationContract]
		string Connect();

		/// <summary>
		/// Отключиться от сервера
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void Disconnect();

		/// <summary>
		/// Получить перечень журналов событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void RequestEventLogs(RequestEventLogsDto dto);

		/// <summary>
		/// Отменить получение перечня журналов событий
		/// </summary>
		/// <param name="id">Идентификатор</param>
		[OperationContract(IsOneWay = true)]
		void CancelEventLogsRequest(long id);

		/// <summary>
		/// Получить записи журнала событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void RequestEventLogEntries(RequestEventLogEntriesDto dto);

		/// <summary>
		/// Отменить получения записей журнала событий
		/// </summary>
		/// <param name="id">Идентификатор</param>
		[OperationContract(IsOneWay = true)]
		void CancelEventLogEntriesRequest(long id);
		
		/// <summary>
		/// Запустить мониторинг журнала событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StartEventMonitoring();
		
		/// <summary>
		/// Остановить мониторинг журнала событий
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StopEventMonitoring();

		/// <summary>
		/// Запустить мониторинг файловой системы
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StartFileWatcher(FileWatcherSettingsDto dto);

		/// <summary>
		/// Остановить мониторинг файловой системы
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StopFileWatcher();

		/// <summary>
		/// Запустить мониторинг устройств
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StartDeviceMonitoring();

		/// <summary>
		/// Остановить мониторинг устройств
		/// </summary>
		[OperationContract(IsOneWay = true)]
		void StopDeviceMonitoring();
	}
}
