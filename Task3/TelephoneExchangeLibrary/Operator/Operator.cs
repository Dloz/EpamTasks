using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public class Operator : IOperator
    {
        public ICollection<IClient> Clients { get; }

        public IStation Station { get; }

        public Operator(IStation station)
        {
            Station = station;
        }

        public void SignContract(IClient client)
        {
            //Create random number
            //Create tariff plan
            

            var contract = new Contract();
            var terminal = new Terminal();
            Station.ConnectTerminal(terminal);

            client.ReceiveTerminal(terminal);
            client.ReceiveContract(contract);
        }
    }
}