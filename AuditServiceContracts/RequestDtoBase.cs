using System;
using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Базовый класс запроса
	/// </summary>
	[DataContract]
	public class RequestDtoBase
	{
		public RequestDtoBase()
		{
			Id = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Идентификатор запроса
		/// </summary>
		[DataMember]
		public string Id { get; set; }
	}
}
