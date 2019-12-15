using System;

namespace TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport
{
    public interface ICallReport
    {
        Guid Id { get; }
        TimeSpan CallDuration { get; }
        DateTime EndedAt { get; }
        DateTime StartedAt { get; }
        int CallerNumber { get; }
        int TargetNumber { get; }
        int Cost { get; }
    }
}