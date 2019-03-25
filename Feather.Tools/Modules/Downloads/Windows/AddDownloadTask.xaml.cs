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

namespace Feather.Tools.Modules.Downloads.Windows
{
    /// <summary>
    /// AddDownloadTask.xaml 的交互逻辑
    /// </summary>
    public partial class AddDownloadTask : Window
    {
        public AddDownloadTask()
        {
            InitializeComponent();
        }

        private void BtnCacel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
