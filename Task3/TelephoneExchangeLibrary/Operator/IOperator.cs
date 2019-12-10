using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IOperator
    {
        IStation Station { get; }
        ICollection<IClient> Clients { get; }

        void SignContract(IClient client);
    }
}