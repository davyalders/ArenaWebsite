using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arena
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetImageUrl();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition","filename=desktop-1.0.jar");
            Response.TransmitFile(Server.MapPath("~/Files/desktop-1.0.jar"));
            Response.End();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetImageUrl();
        }

        private void SetImageUrl()
        {
            if (ViewState["ImageDisplayed"] == null)
            {
                Image1.ImageUrl = "~/Files/1.png";
                ViewState["ImageDisplayed"] = 1;
            }
            else
            {
                int i = (int)ViewState["ImageDisplayed"];
                if (i == 2)
                {
                    Image1.ImageUrl = "~/Files/1.png";
                    ViewState["ImageDisplayed"] = 1;
                }
                else
                {
                    i++;
                    Image1.ImageUrl = "~/Files/" + i.ToString() + ".png";
                    ViewState["ImageDisplayed"] = i;
                }

            }
        }
    }
}