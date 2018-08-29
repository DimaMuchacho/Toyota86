using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Запрос логгеров
	/// </summary>
	[DataContract]
	public class RequestEventLogEntriesDto : RequestDtoBase
	{
		/// <summary>
		/// Имя журнала
		/// </summary>
		[DataMember]
		public string Log { get; set; }

		/// <summary>
		/// Фильтр
		/// </summary>
		[DataMember]
		public EventLogEntryFilter Filter { get; set; }
	}
}
