using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.EventsArgs
{
    public class CallEventArgs: EventArgs
    {
        public int CallerNumber { get; set; }
        public int CallingNumber { get; set; }
    }
}
