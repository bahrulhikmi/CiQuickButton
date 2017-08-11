using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    public class Action
    {
        private Common.ICommand command;
        private String name;

        public Common.ICommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Save()
        {

        }
        
    }
}
