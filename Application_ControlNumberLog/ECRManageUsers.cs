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
    public partial class ECRManageUsers : Form
    {
        public ECRManageUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ECRAddUsers mUser = new ECRAddUsers();
            mUser.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboRemoveUser.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            if (comboRemoveUser.Items.Count <= 1)
            {
                MessageBox.Show("Cannot remove all users...");
                return;
            }


            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to remove this user?", "Remove User?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.eCR_UsersTableAdapter.DeleteByID(Convert.ToInt16(comboRemoveUser.SelectedValue.ToString()));
                MessageBox.Show("User removed");
                this.Close();
            }
            else
            {
                MessageBox.Show("This user was NOT removed");
            }
        }

        private void ECRManageUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataSet1.ECR_Users' table. You can move, or remove it, as needed.
            this.eCR_UsersTableAdapter.Fill(this.motionDataSet1.ECR_Users);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
