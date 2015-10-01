using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class League
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<int> teams { get; set; }
        public List<int> seasons { get; set; }
        public string association { get; set; }
        public string last_updated { get; set; }
        public Address address { get; set; }
    }
}