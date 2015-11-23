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
            Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts","<script>alert('Registration succesful')</script>");
            SendEmail();
            
        }

        public void SendEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            string useractivation = "http://";

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
        }
    }
}