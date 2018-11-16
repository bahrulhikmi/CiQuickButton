using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


/// <summary>
/// This class responsible for executing command
/// </summary>
namespace CommandManager
{
    public class CommandExecutor
    {

        private const string SHIFT = "+";
        private const string CTL = "^";  

        private const int ALT = 0xA4;
        private const int EXTENDEDKEY = 0x1;
        private const int KEYUP = 0x2;
        private const uint Restore = 9;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private static CommandExecutor mInstance;
        public static CommandExecutor Instance
        {
            get
            {
                if(mInstance==null)
                {
                    mInstance = new CommandExecutor();
                }

                return mInstance;
            }
        }

        /// <summary>
        /// Send key to execute Paste Special 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="process"></param>
        public void Execute(Common.IAction command, Common.IProcess process)
        {
            String text = command.GetCommand();
            IntPtr ciWindow = process.getProcess().MainWindowHandle;
            ActivateWindow(ciWindow);
            Clipboard.SetText(text);
            SendKeys.SendWait(CTL+SHIFT+"A");
        }


        public static void ActivateWindow(IntPtr mainWindowHandle)
        {
            //check if already has focus
            if (mainWindowHandle == GetForegroundWindow()) return;

            //check if window is minimized
            if (IsIconic(mainWindowHandle))
            {
                ShowWindow(mainWindowHandle, Restore);
            }

            // Simulate a key press
            keybd_event((byte)ALT, 0x45, EXTENDEDKEY | 0, 0);

            //SetForegroundWindow(mainWindowHandle);

            // Simulate a key release
            keybd_event((byte)ALT, 0x45, EXTENDEDKEY | KEYUP, 0);

            SetForegroundWindow(mainWindowHandle);
        }


    }
}
