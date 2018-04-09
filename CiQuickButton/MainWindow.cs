using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiQuickButton
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSetProcess_Click(object sender, EventArgs e)
        {
            ProcessSelector selector = new ProcessSelector();
            selector.ShowDialog();
            if (ProcessManager.Process.Instance.CurrentProcess != null)
            {
                lblProcessName.Text = ProcessManager.Process.Instance.DescribeCurrentProcess();
            }
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            LoadActions();
        }

        private void LoadActions()
        {
            Action.ActionsCollection actionCollection = new Action.ActionsCollection();
            actionCollection.Load();

            Control btnAddButton = flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count-1];

            flowLayoutPanel1.Controls.Clear();
            foreach(Action.Action action in actionCollection.Actions)
            {
                ActionExecuteControl button = new ActionExecuteControl();
                button.Action = action;
                flowLayoutPanel1.Controls.Add(button);
                button.Click += button2_Click;
                
            }
            flowLayoutPanel1.Controls.Add(btnAddButton);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActionForm actionForm = new ActionForm();
            this.TopMost = false;
            actionForm.ShowDialog();
            this.TopMost = true;
            LoadActions();
        }

        private void lnkManage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ActionsLists actionLists = new ActionsLists();
            this.TopMost = false;
            actionLists.ShowDialog();
            this.TopMost = true;
        }
    }
}
