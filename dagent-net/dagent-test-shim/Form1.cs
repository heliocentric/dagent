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
            this.Main = new AgentControl();
            this.Main.Init(true);
        }
        private AgentControl Main;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
