using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// This class responsible for executing command
/// </summary>
namespace CommandManager
{
    public class CommandExecutor
    {

        private const string SHIFT = "+";
        private const string CTL = "^";

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

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
            SetForegroundWindow(ciWindow);
            Clipboard.SetText(text);
            SendKeys.SendWait(CTL+SHIFT+"A");
        }

    }
}
