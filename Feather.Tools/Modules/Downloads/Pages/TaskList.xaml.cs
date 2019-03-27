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

namespace Feather.Tools.Modules.Downloads.Pages
{
    /// <summary>
    /// TaskList.xaml 的交互逻辑
    /// </summary>
    public partial class TaskList : Page
    {
        public TaskList()
        {
            InitializeComponent();
        }

        public TaskList(Page parent) : this()
        {
            this.DataContext = parent.DataContext;
        }
    }
}
