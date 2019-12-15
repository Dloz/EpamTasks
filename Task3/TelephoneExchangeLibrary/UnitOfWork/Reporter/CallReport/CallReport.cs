using System;
using TelephoneExchangeLibrary.CallRecord;

namespace TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport
{
    public class CallReport: ICallReport
    {
        private ICallRecord _callRecord;

        public Guid Id => _callRecord.Id;
        public TimeSpan CallDuration => _callRecord.CallDuration;
        public DateTime EndedAt => _callRecord.EndedAt;
        public DateTime StartedAt => _callRecord.StartedAt;
        public int CallerNumber => _callRecord.CallerNumber;
        public int TargetNumber => _callRecord.TargetNumber;
        public int Cost { get; }

        public CallReport(ICallRecord callRecord, int cost)
        {
            _callRecord = callRecord;
            Cost = cost;
        }

    }
}