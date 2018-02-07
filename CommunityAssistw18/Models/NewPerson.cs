using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistw18.Models
{
    public class NewPerson
    {
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string PlainPassword { set; get; }
        public string Apartment { set; get; }
        public string Street { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Zipcode { set; get; }
    }
}