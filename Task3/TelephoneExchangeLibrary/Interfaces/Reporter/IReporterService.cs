using System.Collections.Generic;
using TelephoneExchangeLibrary.Interfaces.CallReport;
using TelephoneExchangeLibrary.Interfaces.Client;

namespace TelephoneExchangeLibrary.Interfaces.Reporter
{
    public interface IReporterService
    {
        ICollection<ICallReport> GetReport(IClient client);
    }
}