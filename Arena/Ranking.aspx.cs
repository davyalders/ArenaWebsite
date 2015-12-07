using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arena
{
    public partial class Ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            List<Account> accounts = new List<Account>();
            accounts = Database.GetAccounts().ToList();
            accounts.Sort((x,y) => String.CompareOrdinal(Convert.ToString(x.Rank), Convert.ToString(y.Rank)));
            gridView1.DataSource = accounts;
            gridView1.DataBind();
         
            List<Score> scores = new List<Score>();
            scores = Database.GetScore().ToList();
            accounts.Sort((x,y) => String.CompareOrdinal(Convert.ToString(x.Rank), Convert.ToString(y.Rank)));
            gridView2.DataSource = scores;
            gridView2.DataBind();

        }
    }
}