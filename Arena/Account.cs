using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Arena
{
    public class Account
    {
        public string Username { get; set; }


        public int Rank { get; set; }

        public Account(string username, int rank)
        {
            this.Username = username;
            this.Rank = rank;
        }

        public Account()
        {
            
        }
    }
}