using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_ControlNumberLog
{
    public partial class Login : Form
    {
        public bool Admin = false;
        public string LoggedIn = "Fail";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataSet.User_Info' table. You can move, or remove it, as needed.
            this.user_InfoTableAdapter.Fill(this.motionDataSet.User_Info);
            this.dropName.DisplayMember = "User";
            this.dropName.ValueMember = "ID";
            this.dropName.DataSource = this.motionDataSet.User_Info;
            DataRow dr = motionDataSet.User_Info.NewRow();
            dr[0] = 0;
            dr[1] = "Select User"; //Show in DropDown
            dr[2] = "View Only"; //Assign to this UserGroup
            dr[3] = "123"; //Assign this random password
            motionDataSet.User_Info.Rows.InsertAt(dr, 0);
            dropName.SelectedIndex = 0;
            labelFailPassword.Visible = false;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (dropName.SelectedIndex == 0)
            {
                return;
            }

            bool passing = true;
            int ID = Convert.ToInt16(dropName.SelectedValue.ToString());
            string savedPasswordHash = user_InfoTableAdapter.getPassword(ID);
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    passing = false;
            if (passing == true)
            {
                if (user_InfoTableAdapter.getLevel(ID).ToString() == "Admin")
                {
                    this.Admin = true;
                }
                this.LoggedIn = "Passing";
                this.Close();
            }
            else
            {
                this.LoggedIn = "Failing";
                labelFailPassword.Visible = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dropName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropName.SelectedIndex != 0)
            {
                int ID = Convert.ToInt16(dropName.SelectedValue.ToString());
                txtUserlevel.Text = user_InfoTableAdapter.getLevel(ID).ToString();
            }
            else
            {
                txtUserlevel.Text = string.Empty;
            }
        }
    }
}
