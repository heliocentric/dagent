using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dagent_net_lib;
namespace dagent_test_shim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Main = new Agent();
            this.Main.Init();
        }
        private Agent Main;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Main.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Main.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Main.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Main.Resume();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Main.ForceSync();
        }

    }
}
