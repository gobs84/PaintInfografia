using SuperProject.Services;
using System;
using System.Collections.Generic;

namespace SuperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService ps = new ProductService();
            ps.Read();

            Console.WriteLine("Lista de ejemplo para trabajar\n");
            foreach(Product p in ps.instance.ProductsList)
            {
                Console.WriteLine(p.toString());
            }
            Console.WriteLine("Introduciendo un codigo existente\n");
            Product ej1 = new Product();
            ej1.Code = "1";
            ej1.Name = "Huawei Mate 10 Lite";
            ej1.Price = 270.75;
            ej1.Description = "RNE-L23";
            ej1.Type = Product.typeEnum.physical.ToString();
            ej1.ShippingDeliveryType = Product.shippingDeliveryTypeEnum.express.ToString();
            ej1.Category = null;
            Console.WriteLine(ps.Create(ej1));

            Console.WriteLine("Introduciendo un codigo nuevo\n");
            ej1.Code = "31";
            Console.WriteLine(ps.Create(ej1));

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.instance.ProductsList)
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("Actualizando un producto inexistente\n");
            Product ej2 = new Product();
            ej2.Code = "2";
            ej2.Name = "Huawei Mate 10 pro";
            ej2.Price = 270.75;
            ej2.Description = "...";
            ej2.Type = Product.typeEnum.physical.ToString();
            ej2.ShippingDeliveryType = Product.shippingDeliveryTypeEnum.express.ToString();
            ej2.Category = null;
            Console.WriteLine(ps.Update("0", ej2));

            Console.WriteLine("Actualizando un producto existente\n");
            ej2.Code = "4";
            Console.WriteLine(ps.Update("0", ej2));

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.instance.ProductsList)
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("Borrando un producto que no existe en la lista la lista\n");
            Console.WriteLine(ps.Delete("5"));

            Console.WriteLine("Borrando un producto de la lista");
            Console.WriteLine(ps.Delete("1"));

            Console.WriteLine("Revisando los cambios realizados\n");
            foreach (Product p in ps.instance.ProductsList)
            {
                Console.WriteLine(p.toString());
            }


            Console.ReadKey();
        }
    }
}
