using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttinyListener
{
    interface ISubmiter
    {
        int SubmitInterval
        {
            get;
            set;
        }
        string FieldName
        {
            get;
            set;
        }
        string ApiKey
        {
            get;
            set;
        }
        string ChannelId
        {
            get;
            set;
        }

        bool SubmitData(string data);
        bool TestConnection();
    }
}
