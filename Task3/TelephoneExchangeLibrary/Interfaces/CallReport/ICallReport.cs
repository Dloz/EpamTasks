using TelephoneExchangeLibrary.Interfaces.CallRecord;

namespace TelephoneExchangeLibrary.Interfaces.CallReport
{
    public interface ICallReport: ICallRecord
    {
        decimal Cost { get; }
    }
}