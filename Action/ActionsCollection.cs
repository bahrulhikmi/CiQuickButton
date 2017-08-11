using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Action
{
    class ActionsCollection
    {
        private List<Action> mActions = new List<Action>();

        public List<Action> Actions
        {
            get { return mActions; }
            set { mActions = value; }
        }
                
    }
}
