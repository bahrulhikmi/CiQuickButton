using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface IAction
    {
        Common.ICommand Command
        { get; set; }

        string Name
        { get; set; }
    }
}
