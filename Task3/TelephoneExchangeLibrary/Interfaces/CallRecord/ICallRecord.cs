using System;

namespace TelephoneExchangeLibrary.Interfaces.CallRecord
{
    public interface ICallRecord: IIdentifiable // model don't use interfaces.
    {
        /// <summary>
        /// Represents moment of time in which call has started.
        /// </summary>
        DateTime StartedAt{ get; }
        
        /// <summary>
        /// Represents moment of time in which call has ended.
        /// </summary>
        DateTime EndedAt{ get; set; }
        
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
        
    }
}