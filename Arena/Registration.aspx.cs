using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Arena
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {          
            SendEmail();      
        }

        public void SendEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            string activationcode = Guid.NewGuid().ToString();

            if (Database.SetAccount(tbUsername.Text, tbPassword.Text, tbEmail.Text, activationcode) != -1)
            {
                string useractivation = Request.Url.AbsoluteUri.Replace("Registration.aspx",
                    "Succes.aspx?ActivationCode=" + activationcode);

                message.From = new MailAddress("confirmarena@gmail.com");
                message.To.Add(tbEmail.Text);
                message.Subject = "Account Activation";
                message.Body = "Hello " + tbUsername.Text + "<br>Your email confirmation link: </br><a href = '" +
                               useractivation + "'> click here</a>";
                message.IsBodyHtml = true;
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential("confirmarena@gmail.com", "jezuigt098");
                client.Send(message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Registration succesful')</script>");
            }
            else
            {
                Response.Write("Username is already in use");
            }


        }
    }
}