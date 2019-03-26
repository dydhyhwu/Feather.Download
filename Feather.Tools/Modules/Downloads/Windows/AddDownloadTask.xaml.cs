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
using System.Windows.Shapes;
using Feather.Tools.Modules.Downloads.Models;

namespace Feather.Tools.Modules.Downloads.Windows
{
    /// <summary>
    /// AddDownloadTask.xaml 的交互逻辑
    /// </summary>
    public partial class AddDownloadTask : Window
    {
        private AddTaskModel _model;

        public AddDownloadTask()
        {
            InitializeComponent();
            _model = new AddTaskModel();
            DataContext = _model;
        }

        public string DownloadUrl => _model.Url;

        private void BtnCacel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
