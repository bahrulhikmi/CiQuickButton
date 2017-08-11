using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiQuickButton
{
    public partial class ProcessSelector : Form
    {
        public ProcessSelector()
        {
            InitializeComponent();
        }

        private void ProcessSelector_Load(object sender, EventArgs e)
        {
            loadProcesses();
        }

        private void loadProcesses()
        {

            Dictionary<int, string> processes = ProcessManager.Process.getAllProcesses();

            if (processes.Count == 0) return;

            listProcess.DataSource = new BindingSource(processes, null);
            listProcess.DisplayMember = "Value";
            listProcess.ValueMember = "Key";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessManager.Process.setCurrentProcess(Convert.ToInt32(listProcess.SelectedValue));
            this.Close();
        }
    }
}
