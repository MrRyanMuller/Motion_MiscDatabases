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
    public partial class Search : Form
    {
        public string Change;
        private bool Pass;

        public Search()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Pass == false)
            {
                Change = "%";
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Pass = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtDWGTitle.Text == String.Empty || txtDWGTitle.Text == null)
            {
                Change = "%";
            }
            else
            {
                Change = txtDWGTitle.Text;
            }

            Pass = true;
            this.Close();
        }
    }
}
