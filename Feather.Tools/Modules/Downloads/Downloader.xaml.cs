using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            service = new Aria2JsonRpcService();
        }

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDownloadTask();
            dialog.ShowDialog();
        }
    }
}
