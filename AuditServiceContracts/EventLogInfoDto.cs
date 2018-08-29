using System.Runtime.Serialization;

namespace AuditServiceContracts
{
	/// <summary>
	/// Информация о журнале событий
	/// </summary>
	[DataContract]
	public class EventLogInfoDto
	{
		/// <summary>
		/// Имя
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// Отображаемое имя
		/// </summary>
		[DataMember]
		public string DisplayName { get; set; }
	}
}
