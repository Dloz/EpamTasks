using System.Collections.Generic;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport;

namespace TelephoneExchangeLibrary.UnitOfWork.Reporter
{
    public interface IReporterUnit
    {
        ICollection<ICallReport> GetReport(IClient client);
    }
}