﻿using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace InterestPaymentService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void InterestPaymentServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            new ServiceController(InterestPaymentServiceInstaller.ServiceName).Start();      
        }
    }
   
}
