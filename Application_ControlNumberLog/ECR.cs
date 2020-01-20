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
    public partial class ECR : Form
    {
        private bool LoggedIn = false;
        private bool Admin = false;
        private bool Engineering = false;
        public string User;
        public int UserID;



        public ECR()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);

            // TODO: This line of code loads data into the 'motionDataSet.ECR' table. You can move, or remove it, as needed.
            this.eCRTableAdapter.Fill(this.motionDataSet.ECR);
            ECRLogin mLogin = new ECRLogin();
            mLogin.ShowDialog(this);
            if (mLogin.LoggedIn != "Passing")
            {
                this.Close();
            }

            User = mLogin.User;
            UserID = mLogin.UserID;
            Admin = mLogin.Admin;
            Engineering = mLogin.Engineering;

            if (Admin != true && Engineering != true)
            {
                btnSave.Enabled = false;
                btnSave.Visible = false;

                txtECRNumber.Enabled = false;

                
                txtOriginator.Enabled = false;


                txtDate.Enabled = false;
                txtChange.Enabled = false;
                txtDisposition.Enabled = false;
                comboTypeApproval.Enabled = false;
                comboDecision.Enabled = false;
                txtClosed.Enabled = false;

                btnDelete.Enabled = false;
                btnDelete.Visible = false;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;

                btnSaveTable.Enabled = false;
                btnSaveTable.Visible = false;

                btnManageUsers.Enabled = false;
                btnManageUsers.Visible = false;
            }
            else
            {
                if(Engineering == true)
                {
                    txtOriginator.Enabled = false;
                }

                LoggedIn = true;
            }

            if (mLogin.Level == "Read-Only")
            {
                btnOriginators.Enabled = false;
                btnOriginators.Visible = false;
                btnNotify.Enabled = false;
                btnNotify.Visible = false;
            }


            txtECRNumber.DataBindings.Add(new Binding("Text", bindingSource1, "ECR_Number", true));
            txtOriginator.DataBindings.Add(new Binding("Text", bindingSource1, "Originator", true));
            txtDate.DataBindings.Add(new Binding("Text", bindingSource1, "Date", true));
            txtChange.DataBindings.Add(new Binding("Text", bindingSource1, "Change", true));
            txtDisposition.DataBindings.Add(new Binding("Text", bindingSource1, "Disposition", true));
            comboTypeApproval.DataBindings.Add(new Binding("Text", bindingSource1, "TypeApproval", true));
            comboDecision.DataBindings.Add(new Binding("Text", bindingSource1, "Decision", true));
            txtClosed.DataBindings.Add(new Binding("Text", bindingSource1, "Closed", true));

            bindingSource1.CurrentChanged += new EventHandler(bindingsource_CurrentChanged);
        }

        protected void bindingsource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            int newNum = Convert.ToInt32(eCRTableAdapter.GetIdentity().ToString()) + 1;
            ECRNew mNew = new ECRNew(User, newNum);
            mNew.ShowDialog(this);
            this.eCRTableAdapter.Fill(this.motionDataSet.ECR);
            bindingNavigator1.MoveLastItem.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            eCRTableAdapter.Update(motionDataSet.ECR);
                            break;
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(User != txtOriginator.Text && Engineering == true)
            {
                MessageBox.Show("Engineers can only change their own entries.");
                return;
            }


            if (!checkMandatory()) { return; }
            Validate();
            bindingSource1.EndEdit();
            eCRTableAdapter.Update(motionDataSet.ECR);
            MessageBox.Show("Saved!");
        }

        private bool checkMandatory()
        {
            if (txtECRNumber.Text == "" || txtECRNumber.Text == null)
            {
                MessageBox.Show("ECR Number required!");
                return false;
            }
            return true;
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ECRManageUsers mUsers = new ECRManageUsers();
            mUsers.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkMandatory()) { return; }
            Validate();
            bindingSource1.EndEdit();
            eCRTableAdapter.Update(motionDataSet.ECR);
            MessageBox.Show("Saved!");
        }

        private void txtECRNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void NotAdmin()
        {
            btnSave.Enabled = false;
            btnSave.Visible = false;

            txtChange.Enabled = false;

            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }

        private void IsAdmin()
        {
            btnSave.Enabled = true;
            btnSave.Visible = true;

            txtChange.Enabled = true;

            btnDelete.Enabled = true;
            btnDelete.Visible = true;
        }

        private void btnOriginators_Click(object sender, EventArgs e)
        {
            string mLevel = ecR_UsersTableAdapter1.getLevel(UserID);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to approve this with your name?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (mLevel == "Admin")
            {
                MessageBox.Show("Admins should just use the table view to update signatures.");
                //return;
            }
            else if (mLevel == "Purchasing")
            {
                eCRTableAdapter.UpdatePurchasing(User, Convert.ToInt16(txtECRNumber.Text));
                eCRTableAdapter.Fill(motionDataSet.ECR);
                MessageBox.Show("Thanks for you approval. Confirm your name is shown correctly in the table.");
                return;
            }
            else if (mLevel == "Engineering")
            {
                eCRTableAdapter.UpdateEngineering(User, Convert.ToInt16(txtECRNumber.Text));
                eCRTableAdapter.Fill(motionDataSet.ECR);
                MessageBox.Show("Thanks for you approval. Confirm your name is shown correctly in the table.");
                return;
            }
            else if (mLevel == "Quality Control")
            {
                eCRTableAdapter.UpdateQC(User, Convert.ToInt16(txtECRNumber.Text));
                eCRTableAdapter.Fill(motionDataSet.ECR);
                MessageBox.Show("Thanks for you approval. Confirm your name is shown correctly in the table.");
                return;
            }
            else if (mLevel == "Manufacturing")
            {
                eCRTableAdapter.UpdateManufacturing(User, Convert.ToInt16(txtECRNumber.Text));
                eCRTableAdapter.Fill(motionDataSet.ECR);
                MessageBox.Show("Thanks for you approval. Confirm your name is shown correctly in the table.");
                return;
            }
            else
            {
                MessageBox.Show("There's a problem with your department name. Let an admin know.");
                return;
            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ECRNotify ECRN = new ECRNotify(User, txtECRNumber.Text.ToString());
            ECRN.ShowDialog(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search mSearch = new Search();
            mSearch.ShowDialog(this);
            this.eCRTableAdapter.FillBySearch(this.motionDataSet.ECR, mSearch.Change);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.eCRTableAdapter.Fill(this.motionDataSet.ECR);
        }

        /*Printing*/
        //Print button
        private void btnSort_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }


        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font mFont = new Font("Dot Net Perls", 12);
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            int countLines = 0;
            int maxLines = 20;

            string DataExport = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string DataLine = string.Empty;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string CellVal = cell.Value.ToString();
                    //Shorten long cells
                    if(CellVal.Length > 20)
                    {
                        CellVal = CellVal.Substring(0, 20) + ".....";
                    }

                    if(DataLine != string.Empty)
                    {
                        DataLine += " - ";
                    }
                    DataLine += CellVal;
                }
                DataExport += DataLine + "\r\n";
                countLines++;
                if (countLines >= maxLines)
                    break;
            }
            e.Graphics.DrawString(DataExport, mFont, Brushes.Black, x, y);
        }
        /*End Printing*/

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }



    }
}
