using System;
using TelephoneExchangeLibrary.Interfaces.CallRecord;

namespace TelephoneExchangeLibrary.Models.CallRecord
{
    public class CallRecordModel : ICallRecord 
    {
        /// <summary>
        /// Represents moment of time in which call has started.
        /// </summary>
        public DateTime StartedAt { get; }

        /// <summary>
        /// Represents moment of time in which call has ended.
        /// </summary>
        public DateTime EndedAt { get; set; }
        
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

        public CallRecordModel(int callerNumber, int targetNumber, DateTime startedAt, Guid id)
        {
            CallerNumber = callerNumber;
            TargetNumber = targetNumber;
            StartedAt = startedAt;
            EndedAt = new DateTime(0);
            Id = id;
        }
    }
}
