using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class ShippingAddress
    {
        public string Identifier { set; get; }
        public string Line1 { set; get; }
        public string Line2 { set; get; }
        public int Phone { set; get; }
        public string City { set; get; }
        public string Zone { set; get; }
        public ShippingAddress()
        {
            this.Identifier = "";
            this.Line1 = "";
            this.Line2 = "";
            this.Phone = 0;
            this.City = "";
            this.Zone = "";
        }
    }
}
