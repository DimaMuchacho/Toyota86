using System;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace AuditServiceContracts
{
	/// <summary>
	/// Информация о записи в журнале событий
	/// </summary>
	[DataContract]
	public class EventLogEntryDto
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
		/// Время генерации
		/// </summary>
		[DataMember]
		public DateTime TimeGenerated { get; set; }

		/// <summary>
		/// Время записи
		/// </summary>
		[DataMember]
		public DateTime TimeWritten { get; set; }

		/// <summary>
		/// Индекс
		/// </summary>
		[DataMember]
		public int Index { get; set; }

		/// <summary>
		/// Имя машины
		/// </summary>
		[DataMember]
		public string MachineName { get; set; }

		/// <summary>
		/// Сообщение
		/// </summary>
		[DataMember]
		public string Message { get; set; }
	}
}
