using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.CallRecord
{
    public class CallRecord : ICallRecord, IIdentifiable
    {
        public DateTime StartedAt { get; }

        public DateTime EndedAt { get; private set; }

        public int CallerNumber { get; }

        public int TargetNumber { get; }

        public TimeSpan CallDuration => EndedAt > StartedAt ? (EndedAt - StartedAt) : TimeSpan.Zero;

        public Guid Id { get; }

        public CallRecord(int callerNumber, int targetNumber, DateTime startedAt, Guid id)
        {
            CallerNumber = callerNumber;
            TargetNumber = targetNumber;
            StartedAt = startedAt;
            EndedAt = new DateTime(0);
            Id = id;
        }

        public void EndCall(DateTime endedAt)
        {
            EndedAt = endedAt;
        }
    }
}
