using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Feather.Tools.Application.Services;
using Feather.Tools.Modules.Downloads.Application.Services;
using Feather.Tools.Modules.Downloads.Models;
using Feather.Tools.Modules.Downloads.Pages;
using Feather.Tools.Modules.Downloads.Windows;

namespace Feather.Tools.Modules.Downloads
{
    /// <summary>
    /// Downloader.xaml 的交互逻辑
    /// </summary>
    public partial class Downloader : Page
    {
        private Aria2JsonRpcService service;
        private IAria2Engine _engine;
        private Aria2Model _model;

        public Downloader()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _model = new Aria2Model()
            {
                ActiveTaskList = new ObservableCollection<TaskModel>(),
                WaitingTaskList = new ObservableCollection<TaskModel>(),
                StoppedTaskList = new ObservableCollection<TaskModel>(),
                Speed = 1000,
            };
            DataContext = _model;
            main_content.Content = new Frame()
            {
                Content = new TaskList(this)
            };
            _engine = new Aria2Engine();

            Task.Factory.StartNew(() =>
            {
                _engine.Start();
            });

            service = new Aria2JsonRpcService();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        this.Dispatcher.BeginInvoke(new Action(clear_active_task));
                        var dto = service.TellActive();
                        foreach (var item in dto)
                        {
                            var task = new TaskModel()
                            {
                                Completed = item.completedLength,
                                Total = item.totalLength,
                                Speed = item.downloadSpeed,
                            };
                            this.Dispatcher.BeginInvoke(new Action<TaskModel>(add_active_task), task);
                        }

                        _model.Speed = dto.Count;
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                    }

                }
            });
        }

        #region 线程更新

        private void clear_active_task()
        {
            _model.ActiveTaskList.Clear();
        }

        private void add_active_task(TaskModel task)
        {
            _model.ActiveTaskList.Add(task);
        }

        #endregion

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDownloadTask();
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var tt = service.AddUri(dialog.DownloadUrl);
            }
        }
    }
}
