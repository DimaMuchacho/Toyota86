using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Настройки мониторинга файлов
	/// </summary>
	[DataContract]
	public class FileWatcherSettingsDto
	{
		/// <summary>
		/// Директория для наблюдений
		/// </summary>
		[DataMember]
		public string Path { get; set; }

		/// <summary>
		/// Регистрируемые типы событий
		/// </summary>
		[DataMember]
		public FileEventType EventType { get; set; }
	}
}
