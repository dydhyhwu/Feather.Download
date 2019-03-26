using System;
using System.Collections.Generic;
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
using Feather.Tools.Modules.Downloads.Application.Services;
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

        public Downloader()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            main_content.Content = new Frame()
            {
                Content = new TaskList()
            };

            Task.Factory.StartNew(() =>
            {
                var p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                p.StandardInput.WriteLine(@"cd .\Tools\aria2");
                p.StandardInput.WriteLine(@"aria2c.exe --conf-path=aria2.conf");
                p.WaitForExit();
            });

            service = new Aria2JsonRpcService();
            var x = service.tellStatus("");
        }

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
