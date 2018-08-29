using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Базовый класс ответа на запрос
	/// </summary>
	[DataContract]
	public class ResponseDtoBase
	{
		/// <summary>
		/// Идентификатор запроса
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		[DataMember]
		public string ErrorMessage { get; set; }
	}
}
