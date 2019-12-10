using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IContract: IIdentifiable
    {
        ITariffPlan TariffPlan { get; }
        IOperator Operator { get; }
        int PhoneNumber { get; }
    }
}