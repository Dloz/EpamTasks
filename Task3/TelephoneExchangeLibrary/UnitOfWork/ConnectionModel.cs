using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public class ConnectionModel
    {
        private readonly ValueTuple<int, int, Guid> _connectionTuple;

        public int CallerNumber => _connectionTuple.Item1;
        public int TargetNumber => _connectionTuple.Item2;

        public Guid Id => _connectionTuple.Item3;

        private ConnectionModel()
        {
            _connectionTuple = new ValueTuple<int, int, Guid>();
        }

        public ConnectionModel(ValueTuple<int, int, Guid> connectionTuple): this()
        {
            this._connectionTuple = connectionTuple;
        }

        public ConnectionModel(int callerNumber, int targetNumber, Guid id): this()
        {
            _connectionTuple.Item1 = callerNumber;
            _connectionTuple.Item2 = targetNumber;
            _connectionTuple.Item3 = id;
        }
    }
}
