using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WcfWinService
{
    public partial class MySampleWindowsService : ServiceBase
    {
        private ServiceHost host = null;
        public MySampleWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:2222/MathServices");
            host = new ServiceHost(typeof(MathComponent), baseAddress);
            var contract = typeof(IMathService);
            host.AddServiceEndpoint(contract, new WSHttpBinding(), "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
        }



        protected override void OnStop()
        {
            host.Close();
        }
    }
}
