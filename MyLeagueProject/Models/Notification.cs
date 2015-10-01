using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Notification
    {
        public int id { get; set; }
        public int personid { get; set; }
        public string category { get; set; }
        public string priority { get; set; }
        public string type { get; set; }
        public List<object> @params { get; set; }
        public string status { get; set; }
    }
}