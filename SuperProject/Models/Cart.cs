using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class Cart
    {
        public string Username { get; set; }

        public List<ProductCart> ListPC { get; set; }


        public Cart()
        {
            this.Username = "";
            this.ListPC = new List<ProductCart>();
        }
    }
}
