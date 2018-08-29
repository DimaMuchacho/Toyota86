using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AuditServiceContracts
{
	/// <summary>
	/// Ответ на запрос логгеров
	/// </summary>
	[DataContract]
	public class ResponseEventLogsDto : ResponseDtoBase
	{
		/// <summary>
		/// Журналы
		/// </summary>
		[DataMember]
		public List<EventLogInfoDto> EventLogs { get; set; }
	}
}
