using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Оповещение о записи в журнал событий
	/// </summary>
	[DataContract]
	public class NotifyEventLogEntriesWrittenDto : NotifierDtoBase
	{
		/// <summary>
		/// Имя журнала
		/// </summary>
		[DataMember]
		public string Log { get; set; }

		/// <summary>
		/// Запись
		/// </summary>
		[DataMember]
		public EventLogEntryDto Entry { get; set; }
	}
}
