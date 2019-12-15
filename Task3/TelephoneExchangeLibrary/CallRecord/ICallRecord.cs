using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.CallRecord
{
    public interface ICallRecord: IIdentifiable
    {
        /// <summary>
        /// Represents moment of time in which call has started.
        /// </summary>
        DateTime StartedAt{ get; }
        
        /// <summary>
        /// Represents moment of time in which call has ended.
        /// </summary>
        DateTime EndedAt{ get; }
        
        /// <summary>
        /// Phone number of the caller.
        /// </summary>
        int CallerNumber { get; }
        
        /// <summary>
        /// Phone number of the client was called.
        /// </summary>
        int TargetNumber { get; }
        
        /// <summary>
        /// Amount of time that call has taken.
        /// </summary>
        TimeSpan CallDuration { get; }
        
        /// <summary>
        /// Record the end of active call.
        /// </summary>
        /// <param name="endedAt">Moment of time when call has ended.</param>
        void EndCall(DateTime endedAt);
    }
}