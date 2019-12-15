using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.Client;
using TelephoneExchangeLibrary.UnitOfWork.Reporter.CallReport;

namespace TelephoneExchangeLibrary.UnitOfWork.Reporter
{
    public class ReporterUnit: UnitOfWork, IReporterUnit
    {
        public ICollection<ICallReport> GetReport(IClient client)
        {
            if (client == null)
            {
                throw new ArgumentException("Client is not defined");
            }
            var output = new List<ICallReport>();
            foreach (var contract in client.Contracts)
            {
                var tariff = contract.TariffPlan;
                output.AddRange(
                        from callRecord in contract.CallHistory 
                        let cost = callRecord.CallDuration.Seconds * tariff.Cost 
                        select new CallReport.CallReport(callRecord, cost)
                    );
            }
            return output;
        }
    }
}