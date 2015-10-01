using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Pitch
    {
        public int id { get; set; }
        public Address address { get; set; }
        public string map { get; set; }
    }
}