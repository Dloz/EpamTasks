using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface ICallRecord
    {
        int CallingNumber { get; set; }
        int CallRecievingNumber { get; set; }
        int CallDuration { get; set; }
    }
}