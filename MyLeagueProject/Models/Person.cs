using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITemplateProject.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class Contact
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class AccessLevel
    {
        public string Level { get; set; }
        public string Group { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public DateTime Birth { get; set; }
        public Contact Contact { get; set; }
        public string Role { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public string Status { get; set; }
    }
}