using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class League
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Seasons { get; set; }
        public Address Address { get; set; }
        public string Association { get; set; }
        public string Image { get; set; }
        public string LastUpdated { get; set; }
    }
}