using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiQuickButton
{
    public partial class ActionExecuteControl : UserControl
    {
        private Action.Action mAction;
        public Action.Action Action
        {
            set
            {
                mAction = value;
                if(value!=null)
                {
                    UpdateControl();
                }
            }

            get
            {
                return mAction;
            }
        }


        public ActionExecuteControl()
        {
            InitializeComponent();          
        }


        private void UpdateControl()
        {
            button1.Text = Action.Name;
            
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            if(ProcessManager.Process.Instance.CurrentProcess==null)
            {
                MessageBox.Show("You must select a Ci Application first");
                return;
            }

            CommandManager.CommandExecutor.Instance.Execute(Action, ProcessManager.Process.Instance);
        }
    }

}
