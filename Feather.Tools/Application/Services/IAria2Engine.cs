using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feather.Tools.Application.Presentation;

namespace Feather.Tools.Application.Services
{
    public interface IAria2Engine
    {
        void Start();
        void Stop();
    }

    public class Aria2Engine : IAria2Engine
    {
        private Process _cmd;
        public Aria2Engine()
        {
            _cmd = new Process();
            _cmd.StartInfo.FileName = "cmd.exe";
            _cmd.StartInfo.UseShellExecute = false;
            _cmd.StartInfo.RedirectStandardInput = true;
            _cmd.StartInfo.RedirectStandardOutput = true;
            _cmd.StartInfo.RedirectStandardError = true;
            _cmd.StartInfo.CreateNoWindow = true;
            _cmd.Start();

            ApplicationDelegate.ExitEvent += new MainApplicationExit(this.Stop);
        }

        public void Start()
        {
            _cmd.StandardInput.WriteLine(@"cd .\Tools\aria2");
            _cmd.StandardInput.WriteLine(@"aria2c.exe --conf-path=aria2.conf");
        }

        /// <summary>
        /// 关闭cmd,并且终止aria2c所有进程
        /// </summary>
        public void Stop()
        {
            _cmd.StandardInput.WriteLine("exit");
            _cmd.Kill();

            foreach (var process in Process.GetProcessesByName("aria2c"))
            {
                process.Kill();
            }
        }
    }
}
