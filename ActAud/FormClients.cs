using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using GongSolutions.Shell;
using System.Net;
using GongSolutions.Shell.Interop;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using AuditServiceContracts;

namespace ActAud
{
	/// <summary>
	/// Форма выбора клиентов
	/// </summary>
	public partial class FormClients : Form
	{

		public FormClients()
		{
			InitializeComponent();
			_finder = new NetworkFinder();
			_finder.StateChanged += OnFinderStateChanged;
			_finder.ProgressChanged += OnFinderProgressChanged;
			_finder.Finded += OnFinderFinded;
		}

		/// <summary>
		/// Список серверов
		/// </summary>
		private List<MonServer> serverObjects = new List<MonServer>();

		/// <summary>
		/// Обработчик загрузки формы клиентов
		/// </summary>
		private async void OnFormClientsLoad(object sender, EventArgs e)
		{
			UpdateUI();
			await _finder.StartAsync();
			/*
			try
			{
				//Место для тестового компа, чтобы добавлялся сразу при запуске программы
				var server = new MonServer(IPAddress.Parse("192.168.10.25"));
				server.Initialize();
				if (server.TestConnection())
				{
					AddServer(server);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			 * */
		}

		/// <summary>
		/// Обработчик нахождения сервера
		/// </summary>
		private void OnFinderFinded(object sender, FindedEventArgs e)
		{
			AddServer(e.MonServer);
		}

		/// <summary>
		/// Добавить сервер
		/// </summary>
		private void AddServer(MonServer server)
		{
			serverObjects.Add(server);
			BeginInvoke(new Action(() =>
			{
				var item = new ListViewItem(string.Format("{0} ({1})", server.ServerName, server.IPaddr)) { Tag = server };
				PCListView.Items.Add(item);
			}));
		}

		/// <summary>
		/// Обработчик изменения прогресса поиска серверов
		/// </summary>
		private void OnFinderProgressChanged(object sender, EventArgs e)
		{
			BeginInvoke(new Action(UpdateUI));
		}

		/// <summary>
		/// Обработчик изменения состояния поиска серверов
		/// </summary>
		private void OnFinderStateChanged(object sender, EventArgs e)
		{
			BeginInvoke(new Action(UpdateUI));
		}

		/// <summary>
		/// Обновить пользовательский интерфейс
		/// </summary>
		private void UpdateUI()
		{
			var inProgress = _finder.State == NetworkFinderState.Started || _finder.State == NetworkFinderState.Cancelling;
			RefreshProgressBar.Style = _finder.State == NetworkFinderState.Cancelling ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
			var progress = 0;
			switch(_finder.State)
			{
				case NetworkFinderState.Inactive:
					progress = 0;
					break;
				case NetworkFinderState.Started:
					progress = _finder.Progress;
					break;
				case NetworkFinderState.Finished:
					progress = 100;
					break;
				case NetworkFinderState.Cancelling:
					break;
				case NetworkFinderState.Cancelled:
					progress = 0;
					break;
			}
			RefreshProgressBar.Value = progress;
			RefreshButton.Enabled = _finder.State != NetworkFinderState.Started;
			CancelRefreshButton.Visible = inProgress;
			CancelRefreshButton.Enabled = _finder.State == NetworkFinderState.Started;
		}

		/// <summary>
		/// Объект поиска серверов
		/// </summary>
		private NetworkFinder _finder;

		/// <summary>
		/// Обработчик нажатия на кнопку обновления списка компьютеров
		/// </summary>
		private async void RefreshButton_Click(object sender, EventArgs e)
		{
			await _finder.StartAsync();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку отмены обновления списка компьютеров
		/// </summary>
		private void CancelRefreshButton_Click(object sender, EventArgs e)
		{
			_finder.Cancel();
		}

		/// <summary>
		/// Обработчик двойного клика на списке компьютеров
		/// </summary>
		private void PCListView_DoubleClick(object sender, EventArgs e)
		{
			var selected = PCListView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
			if (selected == null)
				return;
			var server = selected.Tag as MonServer;
			if (server == null)
				return;
			var form = new AuditForm(server);
			form.Show();
		}
	}
}
