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
    public partial class ECRAddUsers : Form
    {
        public ECRAddUsers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Warnings
            if (dropLevel.SelectedIndex < 0)
            {
                MessageBox.Show("Error: Please select level...");
                return;
            }

            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Error: Please a password with at least 4 characters...");
                return;
            }

            if (txtUser.Text.Length < 3)
            {
                MessageBox.Show("Error: Please a username with at least 3 characters...");
                return;
            }

            if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("Error: Password and password confirmation do not match...");
                return;
            }

            if(txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Error: Email is required...");
                return;
            }

            #endregion
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            eCR_UsersTableAdapter.Insert(txtUser.Text, dropLevel.SelectedValue.ToString(), savedPasswordHash, txtEmail.Text);
            this.Close();
        }

        private void ECRAddUsers_Load(object sender, EventArgs e)
        {
            eCR_LevelsTableAdapter.Fill(motionDataSet.ECR_Levels);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
