using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net;
using System.Configuration;

namespace Application_ControlNumberLog
{
    public partial class ECRNotify : Form
    {
        string User;
        string ECRNum;

        public ECRNotify(string mUser, string mECR)
        {
            InitializeComponent();
            User = mUser;
            ECRNum = mECR;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ECRNotify_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataSet.ECR_Users' table. You can move, or remove it, as needed.
            this.ecR_UsersTableAdapter1.Fill(this.motionDataSet.ECR_Users);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dataGridView1.SelectedRows)
            {
                SendMessage(r.Cells[3].Value.ToString(), r.Cells[1].Value.ToString(), User);
            }
            MessageBox.Show("Notifications sent!");
            this.Close();
        }

        protected void SendMessage(string email, string Firstname, string FromMsg)
        {
            string sentFrom = ConfigurationManager.AppSettings.Get("EmailAccount");
            string sentPass = ConfigurationManager.AppSettings.Get("EmailPass");


            MailAddress addressFrom = new MailAddress(sentFrom, "ECR Database");
            MailAddress addressTo = new MailAddress(email);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "New ECR: " + ECRNum;
            message.IsBodyHtml = true;
            string htmlString = @"<html><body><p>Hello " + Firstname + ",<br><br>You have a new notification in the ECR Database - Number: " + ECRNum + "<br><br>This message was sent by: " + FromMsg + "<br><br>Thank you,<br>ECR Database</p></body></html>";
            message.Body = htmlString;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailAccount"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString()),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            client.Send(message);
        }
    }
}
