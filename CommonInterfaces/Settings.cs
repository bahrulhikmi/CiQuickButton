using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Settings
    {
        public static string SaveLocation{
            get
            {
                //TODO: User preferences;
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ActionFiles");
            }
            set
            {

            }
            }

    }
}
