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
    public partial class ControlNumberLog : Form
    {
        private bool LoggedIn = false;
        private bool Admin = false;

        public ControlNumberLog()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataSet.ControlNumberLog' table. You can move, or remove it, as needed.
            this.controlNumberLogTableAdapter.Fill(this.motionDataSet.ControlNumberLog);
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

                txtControlNumber.Enabled = false;
                txtDrawingNumber.Enabled = false;
                txtDateDestroyed.Enabled = false;
                txtDateIssued.Enabled = false;
                txtIssuedBy.Enabled = false;
                txtRev.Enabled = false;
                comboFileType.Enabled = false;

                btnNew.Enabled = false;
                btnNew.Visible = false;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                btnDuplicate.Enabled = false;
                btnDuplicate.Visible = false;

                btnManageUsers.Enabled = false;
                btnManageUsers.Visible = false;

                checkBox1.Visible = false;

                btnSaveTable.Enabled = false;
                btnSaveTable.Visible = false;

                this.txtDateDestroyed.TextChanged -= new System.EventHandler(this.txtDateDestroyed_TextChanged);
            }
            else
            {
                LoggedIn = true;
            }


            txtControlNumber.DataBindings.Add(new Binding("Text", bindingSource1, "ControlNumber", true));
            txtDrawingNumber.DataBindings.Add(new Binding("Text", bindingSource1, "DrawingNumber", true));
            txtDateDestroyed.DataBindings.Add(new Binding("Text", bindingSource1, "DateDestroyed", true));
            txtDateIssued.DataBindings.Add(new Binding("Text", bindingSource1, "DateIssued", true));
            txtIssuedBy.DataBindings.Add(new Binding("Text", bindingSource1, "IssuedBy", true));
            txtRev.DataBindings.Add(new Binding("Text", bindingSource1, "Rev", true));
            comboFileType.DataBindings.Add(new Binding("Text", bindingSource1, "HardCopyOrComputerFile", true));


            if (txtDateDestroyed.Text == string.Empty)
            {
                checkBox1.Checked = false;
                txtDateDestroyed.Enabled = false;
                txtDateDestroyed.ReadOnly = true;
            }
            else
            {
                checkBox1.Checked = true;
                txtDateDestroyed.Enabled = true;
                txtDateDestroyed.ReadOnly = false;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource.AddNew();
            txtControlNumber.Text = (Convert.ToInt32(controlNumberLogTableAdapter.GetIdentity().ToString()) + 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            string temp2 = txtDrawingNumber.Text;
            string temp3 = txtDateIssued.Text;
            string temp4 = txtIssuedBy.Text;
            string temp5 = txtRev.Text;
            string temp6 = txtDateDestroyed.Text;
            string temp7 = comboFileType.Text.ToString();

            bindingNavigator1.BindingSource.AddNew();

            txtControlNumber.Text = (Convert.ToInt32(controlNumberLogTableAdapter.GetIdentity().ToString()) + 1).ToString();
            txtDrawingNumber.Text = temp2;
            txtDateIssued.Text = temp3;
            txtIssuedBy.Text = temp4;
            txtRev.Text = temp5;
            txtDateDestroyed.Text = temp6;
            comboFileType.SelectedText = temp7;
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
                            controlNumberLogTableAdapter.Update(motionDataSet.ControlNumberLog);
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
            controlNumberLogTableAdapter.Update(motionDataSet.ControlNumberLog);
            MessageBox.Show("Saved!");
        }

        private bool checkMandatory()
        {
            if (txtControlNumber.Text == "" || txtControlNumber.Text == null)
            {
                MessageBox.Show("Control Number required!");
                return false;
            }
            return true;
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers mUsers = new ManageUsers();
            mUsers.ShowDialog(this);
        }

        private void txtDateDestroyed_TextChanged(object sender, EventArgs e)
        {
            if (txtDateDestroyed.Text == string.Empty)
            {
                checkBox1.Checked = false;
                txtDateDestroyed.Enabled = false;
                txtDateDestroyed.ReadOnly = true;
            }
            else
            {
                checkBox1.Checked = true;
                txtDateDestroyed.Enabled = true;
                txtDateDestroyed.ReadOnly = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtDateDestroyed.Enabled = true;
                txtDateDestroyed.ReadOnly = false;
            }
            else
            {
                txtDateDestroyed.Enabled = false;
                txtDateDestroyed.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkMandatory()) { return; }
            Validate();
            bindingSource1.EndEdit();
            controlNumberLogTableAdapter.Update(motionDataSet.ControlNumberLog);
            MessageBox.Show("Saved!");
        }
    }
}
