using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public class Contract : IContract
    {
        public ITariffPlan TariffPlan { get; }

        public IOperator Operator { get; }

        public int PhoneNumber { get; }

        public Guid Id { get; }

        public Contract(ITariffPlan tariffPlan, IOperator telephoneOperator, int phoneNumber)
        {
            Id = Guid.NewGuid();
            TariffPlan = tariffPlan;
            Operator = telephoneOperator;
            PhoneNumber = phoneNumber;
        }
    }
}