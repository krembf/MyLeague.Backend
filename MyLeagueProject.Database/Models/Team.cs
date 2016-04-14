using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Player
    {
        public int id { get; set; }
        public int personid { get; set; }
        public string shirt_number { get; set; }
        public string role { get; set; }
    }

    public class Colors
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public int coachid { get; set; }
        public int captainid { get; set; }
        public List<Player> players { get; set; }
        public Colors colors { get; set; }
        public string status { get; set; }
    }
}