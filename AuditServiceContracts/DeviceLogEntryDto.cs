using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Запись журнала устройств
	/// </summary>
	[DataContract]
	public class DeviceLogEntryDto
	{
		/// <summary>
		/// Сообщение
		/// </summary>
		[DataMember]
		public string Message { get; set; }
	}
}
