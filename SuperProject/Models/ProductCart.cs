using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class ProductCart
    {
        public string ProductCode {get; set;}
        public string SelectedDelivery { get; set; }
        public Store Store { get; set;}
        public int Quantity { get; set;}

        public ProductCart()
        {
            this.ProductCode = "";
            this.SelectedDelivery = "";
            this.Store = new Store();
            this.Quantity = 0;
        }


    }
}
