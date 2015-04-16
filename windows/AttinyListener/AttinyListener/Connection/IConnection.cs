using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttinyListener
{
    interface IConnection
    {
        string PortName
        {
            get;
            set;
        }

        int Timeout
        {
            get;
            set;
        }

        string[] AvailablePorts
        {
            get;
        }
        
        bool Open();
        bool Test();
        bool Close();        
    }
}
