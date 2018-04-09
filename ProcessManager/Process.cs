using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace ProcessManager
{
    public class Process : Common.IProcess
    {
        private static Process mInstance;
        public static Process Instance
        {
            get
            {
                if(mInstance==null)
                {
                    mInstance= new Process();
                }

                return mInstance;
            }

        }

        private System.Diagnostics.Process mCurrentProcess;
        public System.Diagnostics.Process CurrentProcess {
            get { return mCurrentProcess; }
            set { mCurrentProcess = value; }
        }

        System.Diagnostics.Process IProcess.getProcess()
        {
            return mCurrentProcess;
        }

        public void setCurrentProcess(int processId)
        {
            CurrentProcess = System.Diagnostics.Process.GetProcessById(processId);
        }

        public Dictionary<int, String> getAllProcesses()
        {
            Dictionary<int, String> processesDict = new Dictionary<int, string>();
          
            System.Diagnostics.Process[] localProcesses = System.Diagnostics.Process.GetProcesses()
                .Where(p=>validProcess(p)).ToArray();

            foreach (System.Diagnostics.Process process in localProcesses)
            {
                    processesDict.Add(process.Id, describe(process));
            }

            return processesDict;
        }

        private static String describe(System.Diagnostics.Process  process)
        {
            return String.Format("{0}({1}), ID: {2} ", process.ProcessName, process.MainWindowTitle, process.Id);
        }

        public string DescribeCurrentProcess()
        {
            if(mCurrentProcess==null)
            {
                return null;
            }

            return describe(mCurrentProcess);
        }

        static int currentSessionId = System.Diagnostics.Process.GetCurrentProcess().SessionId;
        private static Boolean validProcess(System.Diagnostics.Process process)
        {
            return process.SessionId == currentSessionId && process.ProcessName.Contains("T1.Tb");
        }
    }
}
