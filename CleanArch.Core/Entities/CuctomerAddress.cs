using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Core.Entities
{
    public class CuctomerAddress
    {
        public string customerId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string HouseType { get; set; }
        public string Status { get; set; }
    }
}
