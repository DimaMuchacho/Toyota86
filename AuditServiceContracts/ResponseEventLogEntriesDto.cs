using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AuditServiceContracts
{
	/// <summary>
	/// Ответ на запрос записей журнала событий
	/// </summary>
	[DataContract]
	public class ResponseEventLogEntriesDto : ResponseDtoBase
	{
		/// <summary>
		/// Записи
		/// </summary>
		[DataMember]
		public List<EventLogEntryDto> LogEntries { get; set; }
	}
}
