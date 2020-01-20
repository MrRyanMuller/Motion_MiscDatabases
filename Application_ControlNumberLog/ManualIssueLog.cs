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
    public partial class ManualIssueLog : Form
    {
        private bool LoggedIn = false;
        private bool Admin = false;

        public ManualIssueLog()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataSet.ManualIssueLog' table. You can move, or remove it, as needed.
            this.manualIssueLogTableAdapter.Fill(this.motionDataSet.ManualIssueLog);
            Login mLogin = new Login();
            mLogin.ShowDialog(this);
            if (mLogin.LoggedIn != "Passing")
            {
                this.Close();
            }

            Admin = mLogin.Admin;

            if (Admin != true)
            {
                btnSave.Enabled = false;
                btnSave.Visible = false;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;

                txtManualNumber.Enabled = false;
                txtManualName.Enabled = false;
                txtRemoved.Enabled = false;
                txtIssuedTo.Enabled = false;
                txtTOC.Enabled = false;

                btnNew.Enabled = false;
                btnNew.Visible = false;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                btnDuplicate.Enabled = false;
                btnDuplicate.Visible = false;

                btnManageUsers.Enabled = false;
                btnManageUsers.Visible = false;

                btnSaveTable.Enabled = false;
                btnSaveTable.Visible = false;
            }
            else
            {
                LoggedIn = true;
            }


            txtManualNumber.DataBindings.Add(new Binding("Text", bindingSource1, "ManualNumber", true));
            txtManualName.DataBindings.Add(new Binding("Text", bindingSource1, "ManualName", true));
            txtRemoved.DataBindings.Add(new Binding("Text", bindingSource1, "RemovedOrObsolete", true));
            txtIssuedTo.DataBindings.Add(new Binding("Text", bindingSource1, "IssuedTo", true));
            txtTOC.DataBindings.Add(new Binding("Text", bindingSource1, "TOC", true));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource.AddNew();
            txtManualNumber.Text = (Convert.ToInt32(manualIssueLogTableAdapter.GetIdentity().ToString()) + 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            string temp2 = txtManualName.Text;
            string temp3 = txtIssuedTo.Text;
            string temp4 = txtTOC.Text;
            string temp6 = txtRemoved.Text;

            bindingNavigator1.BindingSource.AddNew();

            txtManualNumber.Text = (Convert.ToInt32(manualIssueLogTableAdapter.GetIdentity().ToString()) + 1).ToString();
            txtManualName.Text = temp2;
            txtIssuedTo.Text = temp3;
            txtTOC.Text = temp4;
            txtRemoved.Text = temp6;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource.MoveNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource.MovePrevious();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Do you want to delete this?", "Delete Drawing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    switch (MessageBox.Show(this, "Are you positive?", "Delete Drawing", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            break;
                        default:
                            bindingNavigator1.BindingSource.RemoveCurrent();
                            manualIssueLogTableAdapter.Update(motionDataSet.ManualIssueLog);
                            break;
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkMandatory()) { return; }
            Validate();
            bindingSource1.EndEdit();
            manualIssueLogTableAdapter.Update(motionDataSet.ManualIssueLog);
            MessageBox.Show("Saved!");
        }

        private bool checkMandatory()
        {
            if (txtManualNumber.Text == "" || txtManualNumber.Text == null)
            {
                MessageBox.Show("Manual Number required!");
                return false;
            }
            return true;
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers mUsers = new ManageUsers();
            mUsers.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkMandatory()) { return; }
            Validate();
            bindingSource1.EndEdit();
            manualIssueLogTableAdapter.Update(motionDataSet.ManualIssueLog);
            MessageBox.Show("Saved!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ManualIssueLogSearch mSearch = new ManualIssueLogSearch();
            mSearch.ShowDialog();
            manualIssueLogTableAdapter.FillBySearch(motionDataSet.ManualIssueLog, mSearch.Manual, mSearch.TOC);
        }
    }
}
