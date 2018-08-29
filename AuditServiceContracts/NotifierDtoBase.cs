using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Базовый класс оповещения
	/// </summary>
	[DataContract]
	public class NotifierDtoBase
	{
		public NotifierDtoBase()
		{
			Time = DateTime.Now;
		}

		/// <summary>
		/// Время формирования оповещения
		/// </summary>
		[DataMember]
		public DateTime Time { get; set; }

		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		[DataMember]
		public string ErrorMessage { get; set; }
	}
}
