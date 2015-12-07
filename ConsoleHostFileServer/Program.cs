using System;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Windows.Forms;

namespace ConsoleHostFileServer
{
    class Program
    {
        [DllImport("user32.dll")] 
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); 
        
        [DllImport("kernel32.dll", ExactSpelling = true)] 
        private static extern IntPtr GetConsoleWindow();
        internal delegate void SignalHandler(ConsoleSignal consoleSignal);

        internal enum ConsoleSignal
        {
            CtrlC = 0,
            CtrlBreak = 1,
            Close = 2,
            LogOff = 5,
            Shutdown = 6
        }

        internal static class ConsoleHelper
        {
            [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
            public static extern bool SetSignalHandler(SignalHandler handler, bool add);
        }

        private static SignalHandler _signalHandler;
        private static NotifyIcon _notifyIcon;

        private static void HandleConsoleSignal(ConsoleSignal consoleSignal)
        {
            _notifyIcon.Visible = false;
        }

        private static void InitializeNotifyIcon()
        {
            
            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += (sender, eventArgs) => ShowWindow(GetConsoleWindow(), 1);

            _notifyIcon.Icon = Properties.Resources.server64;
            _notifyIcon.Visible = true; 
            _notifyIcon.Text = @"Это серверная консоль принимаем сюда файлы по сети";
        }

        static void Main()
        {
            _signalHandler += HandleConsoleSignal;
            ConsoleHelper.SetSignalHandler(_signalHandler, true);
            InitializeNotifyIcon();
            
            var myServiceHost = new ServiceHost(typeof(FileService.FileTransferService));
            myServiceHost.Open();

            LogText("Это серверная консоль принимаем сюда файлы по сети " + Environment.NewLine);
            LogText("Сервис запущен!" + Environment.NewLine);

            foreach (var address in myServiceHost.BaseAddresses)
                LogText("Работает сервис " + address + Environment.NewLine);
            
            ShowWindow(GetConsoleWindow(), 0);

            Application.Run();

            myServiceHost.Close();
        }

       

        private static void LogText(string info)
        {
            Console.WriteLine(@"[{0}] {1}", DateTime.Now, info);
        }
    }
}