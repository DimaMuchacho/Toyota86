using System;

namespace AuditServiceContracts
{
	/// <summary>
	/// Константы сервисе
	/// </summary>
	public static class Constants
	{
		public static readonly TimeSpan SendTimeout = TimeSpan.MaxValue;
		public static readonly TimeSpan ReceiveTimeout = TimeSpan.MaxValue;
		public static readonly TimeSpan OpenTimeout = TimeSpan.FromSeconds(2);
		public static readonly TimeSpan CloseTimeout = TimeSpan.FromSeconds(2);
		public static readonly int MaxBufferSize = int.MaxValue;
		public static readonly int MaxReceivedMessageSize = int.MaxValue;
		public static readonly int MaxBufferPoolSize = int.MaxValue;
	}
}
