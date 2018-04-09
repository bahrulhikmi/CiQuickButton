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
    public partial class ActionRowControl : UserControl
    {
        private Action.Action mAction;
        public Action.Action Action{
            get
            {
                return mAction;
            }
            set
            {
                mAction = value;
                if (mAction != null)
                {
                    UpdateControls();
                }
            }
        }

        public ActionRowControl()
        {
            InitializeComponent();
        }

        public void UpdateControls()
        {
            btnPreview.Text = Action.Name;
        }
    }
}
