using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using winmonitorlib;

namespace WindowsFormsApplication1
{
    public partial class WinMonitorConfig : Form
    {
        public WRegistry regkeys;
        public WinMonitorConfig()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnStartRunner_Click(object sender, EventArgs e)
        {
            bkgdRunner.RunWorkerAsync();
        }

        private void btnStopRunner_Click(object sender, EventArgs e)
        {
            bkgdRunner.CancelAsync();
        }

        private void bkgdRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            winmonitorlib.WinMonitor monitor = new winmonitorlib.WinMonitor();
            monitor.Start();
        }

        private void WinMonitorConfig_Load(object sender, EventArgs e)
        {
            this.regkeys = new WRegistry();
            this.txtAPIKey.Text = this.regkeys.APIKey;
            this.txtCompanyID.Text = this.regkeys.CompanyID;
            this.txtComputerID.Text = this.regkeys.ComputerID;
            this.txtURL.Text = this.regkeys.URL;
        }

        private void btnApplyConfig_Click(object sender, EventArgs e)
        {
            regkeys.URL = txtURL.Text;
            regkeys.APIKey = txtAPIKey.Text;
            regkeys.ComputerID = txtComputerID.Text;
            regkeys.CompanyID = txtCompanyID.Text;
        }


    }
}
