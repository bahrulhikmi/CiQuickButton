﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiQuickButton
{
    public partial class ActionForm : Form
    {
        public ActionForm(string ActionName):this()
        {

        }

        public ActionForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Action.Action action = new Action.Action();
            action.Name = tbActionName.Text;
            action.Script = rtbCommand.Text;
            action.Save();
        }
    }
}
