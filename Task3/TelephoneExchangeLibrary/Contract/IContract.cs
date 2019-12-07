using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IContract: IIdentifiable
    {
        //int PhoneNumber { get; }
        int TariffPlan { get; }
        int Operator { get; }
        int Number { get; set; }
    }
}