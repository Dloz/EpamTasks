using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TelephoneExchangeLibrary;
using TelephoneExchangeLibrary.Classes.Operator;
using TelephoneExchangeLibrary.Classes.Station;
using TelephoneExchangeLibrary.Classes.Terminal;
using TelephoneExchangeLibrary.Interfaces.BillingSystem;
using TelephoneExchangeLibrary.Interfaces.Client;
using TelephoneExchangeLibrary.Interfaces.Operator;
using TelephoneExchangeLibrary.Interfaces.Station;
using TelephoneExchangeLibrary.Interfaces.TariffPlan;
using TelephoneExchangeLibrary.Models.BillingSystem;
using TelephoneExchangeLibrary.Models.Client;
using TelephoneExchangeLibrary.Models.TariffPlan;
using TelephoneExchangeLibrary.Services.CallHandler;
using TelephoneExchangeLibrary.Services.Reporter;

namespace TelephoneExchangeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var callHandler = new CallHandlerService();
            var reporter = new ReporterService();
            
            //Populate stations.
            var stations = new List<IStation>();
            IStation station = new Station(callHandler);
            stations.Add(station);
            
            // Populate tariff plans
            var tariffPlans = new List<ITariffPlan>()
            {
                new TariffPlanModel(cost: 4),
                new TariffPlanModel(cost: 10),
                new StandartTariffPlanModel()
            };
            
            IBillingSystem billingSystem = new BillingSystemModel(tariffPlans);
            IOperator phoneOperator = new Operator(stations, billingSystem, reporter);

            reporter.RegisterStation(station);
            reporter.RegisterBillingSystem(billingSystem);
            reporter.RegisterOperator(phoneOperator);

            callHandler.RegisterStation(station);
            callHandler.RegisterBillingSystem(billingSystem);
            callHandler.RegisterOperator(phoneOperator);
            
            // Populate clients.
            var clients = new List<IClient>();
            IClient client1 = new ClientModel();
            IClient client2 = new ClientModel();
            clients.Add(client1);
            clients.Add(client2);
            
            // Register clients
            foreach (var client in clients)
            {
                var (contract, terminal) = phoneOperator
                    .SignContract(
                        billingSystem
                            .TariffPlans
                            .ToList()[new Random().Next(0, billingSystem.TariffPlans.Count() - 1)],
                        client
                    );
                client.Contracts.Add(contract);
                client.Terminals.Add(terminal);
                terminal.Connect();
            }

            var randomTerminal = client2.Terminals.ToList()[new Random().Next(0, client2.Terminals.Count - 1)];
            client1.Terminals.ToList()[new Random().Next(0, client1.Terminals.Count - 1)].Call(randomTerminal.Number);
            
            randomTerminal.Respond();
            
            Thread.Sleep(1000);
            
            randomTerminal.Reject();

            var report = phoneOperator.GetReport(client1);
            foreach (var r in report)
            {
                Console.WriteLine("/////////////////////////////////////////////////");
                Console.WriteLine($"{r.CallerNumber} called {r.TargetNumber} at {r.StartedAt}");
                Console.WriteLine($"Cost: {r.Cost}, Duration: {r.CallDuration.Seconds}");
                Console.WriteLine("/////////////////////////////////////////////////");
            }
        }
    }
}
