using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchangeLibrary.Interfaces.CallReport;
using TelephoneExchangeLibrary.Interfaces.Client;
using TelephoneExchangeLibrary.Interfaces.Reporter;
using TelephoneExchangeLibrary.Models.CallReport;

namespace TelephoneExchangeLibrary.Services.Reporter
{
    public class ReporterService: Service, IReporterService // service
    {
        public ICollection<ICallReport> GetReport(IClient client) // argument: clientId, return report
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
                        select new CallReportModel(callRecord, cost)
                    );
            }
            return output;
        }
    }
}