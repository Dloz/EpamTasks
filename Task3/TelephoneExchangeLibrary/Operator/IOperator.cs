using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IOperator
    {
        int Clients { get; set; }

        void SignContract(IClient client);
    }
}