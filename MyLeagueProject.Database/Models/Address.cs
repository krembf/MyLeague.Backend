using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2} {3}", street, city, state, zip);
        }
    }
}