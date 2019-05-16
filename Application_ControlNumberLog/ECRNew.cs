using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_ControlNumberLog
{
    public partial class ECRNew : Form
    {
        public ECRNew(string Originator, int Num)
        {
            InitializeComponent();
            txtOriginator.Text = Originator;
            txtECRNumber.Text = Num.ToString();
            txtDate.Text = DateTime.Now.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ECRNew_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ecrTableAdapter1.Insert(Convert.ToInt16(txtECRNumber.Text), txtOriginator.Text, txtDate.Text, null, txtChange.Text, null, null, null, null, null, null, null);
            this.Close();
        }
    }
}
