using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arena
{
    public class Score
    {
        public int AccountID { get; set; }

        public int Kills { get; set; }

        public int LivesLeft { get; set; }

        public int HpLeft { get; set; }

        public int Tijd { get; set; }

        public Score()
        {

        }
    }

   
}