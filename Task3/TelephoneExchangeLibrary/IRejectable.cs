using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface IRejectable
    {
        void Reject(object sender, RejectEventArgs e);
    }
}