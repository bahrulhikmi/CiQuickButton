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
    public partial class ActionsLists : Form
    {
        public ActionsLists()
        {
            InitializeComponent();
        }

        private void ActionsLists_Load(object sender, EventArgs e)
        {
            loadActions();
        }

        private void loadActions()
        {
            Action.ActionsCollection actions = new Action.ActionsCollection();
            actions.Load();

            foreach(Action.Action action in actions.Actions)
            {
                ActionRowControl row = new ActionRowControl();
                row.Action = action;
                flowLayoutPanel1.Controls.Add(row);
                flowLayoutPanel1.Refresh();
            }            
        }
    }
}
