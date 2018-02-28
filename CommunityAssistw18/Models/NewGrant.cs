using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistw18.Models
{
    public class NewGrant
    {
        public string Type { set; get; }
        public decimal Amount { set; get; }
        public string Reason { set; get; }
    }
}