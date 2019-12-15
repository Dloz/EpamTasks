using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.CallRecord
{
    public class CallRecord : ICallRecord
    {
        /// <summary>
        /// Represents moment of time in which call has started.
        /// </summary>
        public DateTime StartedAt { get; }

        /// <summary>
        /// Represents moment of time in which call has ended.
        /// </summary>
        public DateTime EndedAt { get; private set; }
        
        /// <summary>
        /// Phone number of the caller.
        /// </summary>
        public int CallerNumber { get; }
        
        /// <summary>
        /// Phone number of the client was called.
        /// </summary>
        public int TargetNumber { get; }
        
        /// <summary>
        /// Amount of time that call has taken.
        /// </summary>
        public TimeSpan CallDuration => EndedAt > StartedAt ? (EndedAt - StartedAt) : TimeSpan.Zero;
        
        /// <summary>
        /// Call identifier.
        /// </summary>
        public Guid Id { get; }

        public CallRecord(int callerNumber, int targetNumber, DateTime startedAt, Guid id)
        {
            CallerNumber = callerNumber;
            TargetNumber = targetNumber;
            StartedAt = startedAt;
            EndedAt = new DateTime(0);
            Id = id;
        }
        
        /// <summary>
        /// Record the end of active call.
        /// </summary>
        /// <param name="endedAt">Moment of time when call has ended.</param>
        public void EndCall(DateTime endedAt)
        {
            EndedAt = endedAt;
        }
    }
}
