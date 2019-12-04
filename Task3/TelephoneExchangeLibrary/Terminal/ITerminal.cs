using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface ITerminal: IIdentifiable
    {
        int Number { get; set; }
    }
}