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
            if (ProcessManager.Process.CurrentProcess != null)
            {
                lblProcessId.Text = ProcessManager.Process.CurrentProcess.Id.ToString();
                lblProcessName.Text = ProcessManager.Process.CurrentProcess.ProcessName;
            }
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
