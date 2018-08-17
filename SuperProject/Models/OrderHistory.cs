using SuperProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class OrderHistory
    {
        public Cart Cart { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public string UserName { get; set; }
        public OrderHistory()
        {
            this.Cart = new Cart();
            this.ShippingAddress = new ShippingAddress();
            this.UserName = "";
        }
    }
}
