using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feather.Tools.Application.Presentation
{
    public delegate void MainApplicationExit();

    public static class ApplicationDelegate
    {
        public static event MainApplicationExit ExitEvent;

        public static void Exit()
        {
            ExitEvent?.Invoke();
        }
    }
}
