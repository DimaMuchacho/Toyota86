using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditServiceContracts
{
	/// <summary>
	/// Код типа записи в журнале событий для фильтрации
	/// </summary>
	public enum EventLogEntryTypeFilter
	{
		None = 0,
		Error = 1,
		Warning = 2,
		Information = 4,
		SuccessAudit = 8,
		FailureAudit = 16,
	}
}
