using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Оповещение об изменениях в файловой системе
	/// </summary>
	[DataContract]
	public class NotifyFileWatcherEventDto : NotifierDtoBase
	{
		/// <summary>
		/// Запись об изменении
		/// </summary>
		[DataMember]
		public FileWatcherLogEntryDto Entry { get; set; }
	}
}
