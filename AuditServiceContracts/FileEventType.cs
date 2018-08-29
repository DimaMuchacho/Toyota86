using System;

namespace AuditServiceContracts
{
	/// <summary>
	/// Тип отслеживания изменений в файловой системе
	/// </summary>
	[Flags]
	public enum FileEventType
	{
		/// <summary>
		/// Не задан
		/// </summary>
		None = 0x0,

		/// <summary>
		/// Изменение
		/// </summary>
		Changed = 0x1,

		/// <summary>
		/// Создание
		/// </summary>
		Created = 0x2,

		/// <summary>
		/// Удаление
		/// </summary>
		Deleted = 0x4,

		/// <summary>
		/// Переименование
		/// </summary>
		Renamed = 0x8,

		/// <summary>
		/// Все
		/// </summary>
		All = Changed | Created | Deleted | Renamed
	}
}
