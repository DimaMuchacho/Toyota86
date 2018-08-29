using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

using GongSolutions.Shell;
using GongSolutions.Shell.Interop;

using AuditServiceContracts;

namespace ActAud
{
	/// <summary>
	/// Статус поиска компьютеров
	/// </summary>
	public enum NetworkFinderState
	{
		/// <summary>
		/// Не запускался
		/// </summary>
		Inactive = 0,

		/// <summary>
		/// Запущен
		/// </summary>
		Started = 1,

		/// <summary>
		/// Подана команда на отмену
		/// </summary>
		Cancelling = 2,

		/// <summary>
		/// Отменен
		/// </summary>
		Cancelled = 3,

		/// <summary>
		/// Завершен
		/// </summary>
		Finished = 4
	}

	/// <summary>
	/// Аргументы события нахождения компьютера
	/// </summary>
	public class FindedEventArgs : EventArgs
	{
		public FindedEventArgs(MonServer monServer)
		{
			_monServer = monServer;
		}

		private readonly MonServer _monServer;
		/// <summary>
		/// Сервер
		/// </summary>
		public MonServer MonServer
		{
			get { return _monServer; }
		}
	}

	/// <summary>
	/// Класс для поиска компьютеров в сети
	/// </summary>
	public class NetworkFinder
	{
		public NetworkFinder()
		{
		}

		private NetworkFinderState _state;
		/// <summary>
		/// Статус
		/// </summary>
		public NetworkFinderState State
		{
			get { return _state; }
			private set
			{
				if (_state == value)
					return;
				_state = value;
				StateChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Событие изменения состояния поиска
		/// </summary>
		public event EventHandler StateChanged = delegate { };

		private int _progress;
		/// <summary>
		/// Прогресс поиска
		/// </summary>
		public int Progress
		{
			get { return _progress; }
			private set
			{
				if (_progress == value)
					return;
				_progress = value;
				ProgressChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Событие изменения прогресса поиска
		/// </summary>
		public event EventHandler ProgressChanged = delegate { };

		private CancellationTokenSource _cancelStartingTokenSource;
		/// <summary>
		/// Источник токена для отмены обновления
		/// </summary>
		private CancellationTokenSource CancelStartingTokenSource
		{
			get { return _cancelStartingTokenSource; }
			set
			{
				if (_cancelStartingTokenSource == value)
					return;
				if (_cancelStartingTokenSource != null)
				{
					_cancelStartingTokenSource.Dispose();
				}
				_cancelStartingTokenSource = value;
			}
		}

		/// <summary>
		/// Запустить поиск
		/// </summary>
		public async Task StartAsync()
		{
			if (State == NetworkFinderState.Started)
				return;
			CancelStartingTokenSource = new CancellationTokenSource();
			State = NetworkFinderState.Started;
			Progress = 0;
			Progress += _networkCountCalcProgress;
			if (CancelStartingTokenSource.IsCancellationRequested)
				goto finish;
			var network = await Task.Run(() => new ShellItem((Environment.SpecialFolder)CSIDL.NETWORK));
			Progress += _networkCountCalcProgress;
			if (CancelStartingTokenSource.IsCancellationRequested)
				goto finish;
			_networkCount = await Task.Run(() => network.Count());
			Progress += _networkCountCalcProgress;
			if (CancelStartingTokenSource.IsCancellationRequested)
				goto finish;
			NetworkProgress = 0;
			await Task.Run(() => Parallel.ForEach(network, n => TryConnect(n.ParsingName, CancelStartingTokenSource.Token)));
			finish:
			State = CancelStartingTokenSource.IsCancellationRequested ? NetworkFinderState.Cancelled : NetworkFinderState.Finished;
		}

		/// <summary>
		/// Прогресс закладываемый на выполнения операции поиска и перечисления
		/// </summary>
		private const int _networkCountCalcProgress = 5;

		private int _networkCount;

		public int _networkProgress;
		/// <summary>
		/// Прогресс работы по сети
		/// </summary>
		public int NetworkProgress
		{
			get { return _networkProgress; }
			set
			{
				_networkProgress = value;
				if (_networkCount == 0)
				{
					Progress = 0;
				}
				else
				{
					Progress = (int)((100D - _networkCountCalcProgress * 3) * _networkProgress / _networkCount) + _networkCountCalcProgress * 3;
				}
			}
		}

		public void Cancel()
		{
			if (State != NetworkFinderState.Started)
				return;
			State = NetworkFinderState.Cancelling;
			if (CancelStartingTokenSource != null)
				CancelStartingTokenSource.Cancel();
		}

		private void TryConnect(string hostName, CancellationToken cancelToken)
		{
			IPAddress[] ips = null;
			try
			{
				ips = Dns.GetHostAddresses(hostName.Remove(0, 2));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(hostName + ": " + ex.Message);
				goto finish;
			}
			foreach (var ip in ips.Where(a => a.AddressFamily == AddressFamily.InterNetwork))
			{
				var server = new MonServer(ip);
				try
				{
					server.Initialize();
					if (server.TestConnection())
					{
						Finded(this, new FindedEventArgs(server));
					}
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
				if (cancelToken.IsCancellationRequested)
				{
					System.Diagnostics.Debug.WriteLine(string.Format("Операция для {0} отменена", hostName));
					goto finish;
				}
			}
			finish:
			++NetworkProgress;
		}

		/// <summary>
		/// Событие нахождения компьютера
		/// </summary>
		public event EventHandler<FindedEventArgs> Finded = delegate { };

	}
}
