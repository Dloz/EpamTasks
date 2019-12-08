using System;
using System.Collections.Generic;
using System.Text;
using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary
{
    public interface IRespondable
    {
        void Respond(object sender, RespondEventArgs e);
    }
}