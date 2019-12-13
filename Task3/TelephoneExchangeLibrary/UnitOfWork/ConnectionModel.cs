using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public class ConnectionModel
    {
        private ValueTuple<int, int, Guid> connectionTuple;

        public int CallerNumber => connectionTuple.Item1;
        public int TargetNumber => connectionTuple.Item2;

        public Guid Id => connectionTuple.Item3;

        public ConnectionModel()
        {
            connectionTuple = new ValueTuple<int, int, Guid>();
        }

        public ConnectionModel(ValueTuple<int, int, Guid> connectionTuple): this()
        {
            this.connectionTuple = connectionTuple;
        }

        public ConnectionModel(int callerNumber, int targetNumber, Guid id): this()
        {
            connectionTuple.Item1 = callerNumber;
            connectionTuple.Item2 = targetNumber;
            connectionTuple.Item3 = id;
        }
    }
}
