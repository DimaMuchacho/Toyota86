using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Оповещение о состоянии работы мониторинга
	/// </summary>
	[DataContract]
	public class NotifyMonitoringStateDto : NotifierDtoBase
	{
		/// <summary>
		/// Состояние мониторинга
		/// </summary>
		[DataMember]
		public MonitoringState State { get; set; }
	}
}
