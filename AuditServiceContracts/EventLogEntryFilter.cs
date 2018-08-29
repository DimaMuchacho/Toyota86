using System;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace AuditServiceContracts
{
	/// <summary>
	/// Фильтр по записям в журнале событий
	/// </summary>
	[DataContract]
	public class EventLogEntryFilter
	{
		/// <summary>
		/// Идентификатор экземпляра
		/// </summary>
		[DataMember]
		public long InstanceId { get; set; }

		/// <summary>
		/// Тип события
		/// </summary>
		[DataMember]
		public EventLogEntryTypeFilter EntryType { get; set; }

		/// <summary>
		/// Время генерации, от
		/// </summary>
		[DataMember]
		public DateTime TimeGeneratedFrom { get; set; }

		/// <summary>
		/// Время генерации, до
		/// </summary>
		[DataMember]
		public DateTime TimeGeneratedTo { get; set; }

		/// <summary>
		/// Имя машины
		/// </summary>
		[DataMember]
		public string MachineName { get; set; }

		/// <summary>
		/// Часть сообщения
		/// </summary>
		[DataMember]
		public string MessagePart { get; set; }
	}
}
