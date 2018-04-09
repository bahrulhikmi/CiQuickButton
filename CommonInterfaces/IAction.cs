using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface IAction
    {
        string GetCommand();

        string Name
        { get; set; }
    }
}
