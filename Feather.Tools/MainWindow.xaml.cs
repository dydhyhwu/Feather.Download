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
using Feather.Tools.Application.Presentation;
using Feather.Tools.Modules.Downloads;
using Feather.Tools.Modules.Downloads.Application.Services;

namespace Feather.Tools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            main_content.Content = new Frame()
            {
                Content = new Downloader()
            };
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            ApplicationDelegate.Exit();
            System.Environment.Exit(0);
        }
    }
}
