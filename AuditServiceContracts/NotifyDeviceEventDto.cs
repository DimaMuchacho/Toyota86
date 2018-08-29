using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Оповещение мониторинга устройств
	/// </summary>
	[DataContract]
	public class NotifyDeviceEventDto : NotifierDtoBase
	{
		/// <summary>
		/// Сообщение
		/// </summary>
		[DataMember]
		public string Message { get; set; }
	}
}
