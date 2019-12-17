using System;
using TelephoneExchangeLibrary.Interfaces.CallRecord;
using TelephoneExchangeLibrary.Interfaces.CallReport;

namespace TelephoneExchangeLibrary.Models.CallReport
{
    public class CallReportModel: ICallReport
    {
        private ICallRecord _callRecord;

        public Guid Id => _callRecord.Id;
        public TimeSpan CallDuration => _callRecord.CallDuration;
        public DateTime EndedAt => _callRecord.EndedAt;
        public DateTime StartedAt => _callRecord.StartedAt;
        public int CallerNumber => _callRecord.CallerNumber;
        public int TargetNumber => _callRecord.TargetNumber;
        public decimal Cost { get; }
        DateTime ICallRecord.EndedAt { get => _callRecord.EndedAt; set => _callRecord.EndedAt = value; }

        public CallReportModel(ICallRecord callRecord, int cost)
        {
            _callRecord = callRecord;
            Cost = cost;
        }

    }
}