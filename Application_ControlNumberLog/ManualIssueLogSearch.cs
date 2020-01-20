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
    public partial class ManualIssueLogSearch : Form
    {
        public string TOC;
        public string Manual;
        private bool Pass;

        public ManualIssueLogSearch()
        {
            InitializeComponent();
        }

        private void ManualIssueLogSearch_Load(object sender, EventArgs e)
        {
            Pass = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtManualName.Text == String.Empty || txtManualName.Text == null)
            {
                Manual = "%";
            }
            else
            {
                Manual = txtManualName.Text;
            }

            if(txtTOC.Text == String.Empty || txtTOC.Text == null)
            {
                TOC = "%";
            }
            else
            {
                TOC = txtTOC.Text;
            }

            Pass = true;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Pass == false)
            {
                TOC = "%";
                Manual = "%";
            }
        }
    }
}
