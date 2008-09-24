using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using log4net;

namespace Service
{
    public partial class tbService : ServiceBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(tbService));

        public tbService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.Debug("Service started!");
        }

        protected override void OnStop()
        {
            Log.Debug("Service stoped!");
        }
    }
}
