using SalesInfoService.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoService.Presentation.WindowsService
{
    public partial class SalesInfoService : ServiceBase
    {
        private Facade _facade;
        public SalesInfoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _facade = new Facade();
            _facade.Run();
        }

        protected override void OnStop()
        {
            _facade.Stop();
        }
    }
}
