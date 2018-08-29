using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Сообщение в журнале изменений файловой системы
	/// </summary>
	[DataContract]
	public class FileWatcherLogEntryDto
	{
		/// <summary>
		/// Тип событий
		/// </summary>
		[DataMember]
		public FileEventType EventType { get; set; }

		/// <summary>
		/// Сообщение
		/// </summary>
		[DataMember]
		public string Message { get; set; }
	}
}
