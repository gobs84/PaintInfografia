using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class Product
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } 
        public string ImageURL { get; set; }
        public enum typeEnum : int { physical, digital, nulo};
        public typeEnum type { get; set; }
        public enum shippingDeliveryTypeEnum : int { nulo = -1, express = 1, normal = 2, inStore = 3, free = 4, none = 0};
        public shippingDeliveryTypeEnum shippingDeliveryType { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            Code = "";
            Name = "";
            Price = 0.0;
            Description = "";
            ImageURL = "";
            type = typeEnum.nulo;
            shippingDeliveryType = shippingDeliveryTypeEnum.nulo;
            Category = new Category();
        }

        public string toString()
        {
            return "Codigo = " + Code + "\nNombre = " + Name + "\nPrecio = " + Price + "\nTipo = " + Type + "\nTipo de entrega = " + ShippingDeliveryType + "\nCategoria = " + Category;
        }

        public string Type
        {
            get
            {
                return this.type.ToString();
            }
            set
            {
                switch (value)
                {
                    case "physical":
                        this.type = typeEnum.physical;
                        break;
                    case "digital":
                        this.type = typeEnum.digital;
                        this.shippingDeliveryType = shippingDeliveryTypeEnum.none;
                        break;
                    default:
                        this.type = typeEnum.nulo;
                        break;
                }
            }
        }

        public string ShippingDeliveryType
        {
            get
            {
                return this.shippingDeliveryType.ToString();
            }
            set
            {
                if (!Type.ToString().Equals("digital"))
                {
                    switch (value)
                    {
                        case "express":
                            this.shippingDeliveryType = shippingDeliveryTypeEnum.express;
                            break;
                        case "normal":
                            this.shippingDeliveryType = shippingDeliveryTypeEnum.normal;
                            break;
                        case "inStore":
                            this.shippingDeliveryType = shippingDeliveryTypeEnum.inStore;
                            break;
                        case "free":
                            this.shippingDeliveryType = shippingDeliveryTypeEnum.free;
                            break;
                        default:
                            this.shippingDeliveryType = shippingDeliveryTypeEnum.nulo;
                            break;
                    }
                }
            }
        }
            
    }
}
