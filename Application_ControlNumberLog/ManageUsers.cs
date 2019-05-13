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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUsers mUser = new AddUsers();
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
                this.user_InfoTableAdapter.DeleteByID(Convert.ToInt16(comboRemoveUser.SelectedValue.ToString()));
                MessageBox.Show("User removed");
                this.Close();
            }
            else
            {
                MessageBox.Show("This user was NOT removed");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            this.user_InfoTableAdapter.Fill(this.motionDataSet1.User_Info);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
