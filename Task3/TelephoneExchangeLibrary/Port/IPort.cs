using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IPort: IIdentifiable
    {
        int Status { get; set; }
    }
}