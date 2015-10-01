using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Contact
    {
        public string phone { get; set; }
        public string email { get; set; }
        public string skype { get; set; }
    }

    public class Documents
    {
        public int season { get; set; }
        public string document { get; set; }
    }

    public class Payments
    {
        public int season { get; set; }
        public List<string> payment_method { get; set; }
    }

    public class AccessLevel
    {
        public int level { get; set; }
        public string group { get; set; }
    }

    public class Person
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public Address address { get; set; }
        public string birth { get; set; }
        public string photo { get; set; }
        public Contact contact { get; set; }
        public Documents documents { get; set; }
        public Payments payments { get; set; }
        public string role { get; set; }
        public AccessLevel access_level { get; set; }
        public string status { get; set; }
        public List<Notification> notifications { get; set; }
    }

    public class RootObject
    {
        public Person person { get; set; }
    }

}