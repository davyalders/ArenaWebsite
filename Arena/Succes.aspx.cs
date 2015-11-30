using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arena
{
    public partial class Succes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                reg3.Visible = false;
                string activation = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"])
                    ? Request.QueryString["ActivationCode"]
                    : Guid.Empty.ToString();
                if (Database.ActivateAccount(activation) != -1)
                {
                    reg3.Visible = true;
                }
                else
                {
                    reg3.Visible = false;
                }
            }
        }
    }
}