using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary.CallRecord
{
    public interface ICallRecord: IIdentifiable
    {
        DateTime StartedAt{ get; }
        DateTime EndedAt{ get; }
        int CallerNumber { get; }
        int TargetNumber { get; }
        TimeSpan CallDuration { get; }
        void EndCall(DateTime endedAt);
    }
}