using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Season
    {
        public int id { get; set; }
        public int leagueid { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public List<Team> teams { get; set; }
        public List<int> games { get; set; }
    }
}