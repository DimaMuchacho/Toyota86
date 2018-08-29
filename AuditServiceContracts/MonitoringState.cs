namespace AuditServiceContracts
{
	/// <summary>
	/// Состояние запуска мониторинга
	/// </summary>
	public enum MonitoringState
	{
		/// <summary>
		/// Не запускался
		/// </summary>
		NotStarted,

		/// <summary>
		/// Запущен
		/// </summary>
		Started,

		/// <summary>
		/// Остановлен
		/// </summary>
		Stopped
	}
}
