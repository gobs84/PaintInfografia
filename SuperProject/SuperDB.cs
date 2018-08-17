using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject
{
    public class SuperDB
    {
        private static SuperDB _instance;

        private SuperDB() {
            Initiate();
        }

        private void Initiate()
        {
            this.CartsList = new List<Cart>();
            this.CategorysList = new List<Category>();
            this.ProductsList = new List<Product>();
            this.StoresList = new List<Store>();
            this.UsersList = new List<User>();
            this.ProductCartList = new List<ProductCart>();
            this.ShippingAddressesList = new List<ShippingAddress>();
            this.CategorysList.Add(new Category() { Name = "New", Description = "Not Used" });
            this.CategorysList.Add(new Category() { Name = "Not so new", Description = "Slightly Used" });
            this.CategorysList.Add(new Category() { Name = "Old", Description = "Used" });
            this.CategorysList.Add(new Category() { Name = "Rounded", Description = "Without Corners" });
            this.CategorysList.Add(new Category() { Name = "Squared", Description = "Without Curves" });
            this.ShippingAddressesList.Add(new ShippingAddress() { Identifier = "casa", Line1 = "asd", Line2 = "123", Phone = 1, City = "cbba", Zone = "Temporal" });
            this.ShippingAddressesList.Add(new ShippingAddress() { Identifier = "oficina", Line1 = "asd", Line2 = "123", Phone = 2, City = "cbba", Zone = "centro" });
            this.ShippingAddressesList.Add(new ShippingAddress() { Identifier = "oficina2", Line1 = "asd", Line2 = "123", Phone = 3, City = "cbba", Zone = "America oeste" });
            this.ShippingAddressesList.Add(new ShippingAddress() { Identifier = "casa2", Line1 = "asd", Line2 = "123", Phone = 4, City = "cbba", Zone = "parque Lincoln" });
            this.ShippingAddressesList.Add(new ShippingAddress() { Identifier = "tienda", Line1 = "asd", Line2 = "123", Phone = 5, City = "cbba", Zone = "Muyurina" });
            this.StoresList.Add(new Store() { Name = "New York", Line1 = "a", Line2 = "b", Phone = 1 });
            this.StoresList.Add(new Store() { Name = "Chicago", Line1 = "c", Line2 = "d", Phone = 2 });
            this.StoresList.Add(new Store() { Name = "La Paz", Line1 = "e", Line2 = "f", Phone = 3 });
            this.StoresList.Add(new Store() { Name = "Cochabamba", Line1 = "g", Line2 = "h", Phone = 4 });
            this.StoresList.Add(new Store() { Name = "Moscu", Line1 = "i", Line2 = "j", Phone = 5 });
            this.UsersList.Add(new User { Username = "user1", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            this.UsersList.Add(new User { Username = "user2", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            this.UsersList.Add(new User { Username = "user3", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            this.UsersList.Add(new User { Username = "user4", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            this.UsersList.Add(new User { Username = "user5", Name = "name", LastName = "last name", Password = "password", ShippingAddresses = new List<ShippingAddress>() });
            this.ProductsList.Add(new Product { Code = "0", Name = "Head Phones", Price = 20.75, ImageURL = "http://www.quetalcompra.com/upload/goods/4_Accesorios-de-Celulares/401_AURICULARES/401001-401030/401022_Honor%20AM115_M2.jpg", Description = "Audifonos huawei", Type = Product.typeEnum.physical.ToString(), ShippingDeliveryType = Product.shippingDeliveryTypeEnum.inStore.ToString(), Category = CategorysList.Find(cl => cl.Name == "Old") });
            this.ProductsList.Add(new Product { Code = "1", Name = "Mouse", Price = 17.5, ImageURL = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1r7v9?ver=cdb6&q=90&m=6&h=423&w=752&b=%23FFFFFFFF&f=jpg&o=f&aim=true", Description = "Mouse inalambrico para portatil", Type = Product.typeEnum.physical.ToString(), ShippingDeliveryType = Product.shippingDeliveryTypeEnum.express.ToString(), Category = CategorysList.Find(cl => cl.Name == "New") });
            this.ProductsList.Add(new Product { Code = "2", Name = "Windows Pro", Price = 120.75, ImageURL = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1B9Ku?ver=317a&q=90&m=6&h=423&w=752&b=%23FFFFFFFF&o=f&aim=true", Description = "Licencia digital para activacion de Windows Pro", Type = Product.typeEnum.digital.ToString(), ShippingDeliveryType = Product.shippingDeliveryTypeEnum.none.ToString(), Category = CategorysList.Find(cl => cl.Name == "Not so new") });
            this.ProductCartList.Add(new ProductCart { ProductCode = ProductsList[1].Code, SelectedDelivery = ProductsList[1].ShippingDeliveryType, Store = StoresList[1], Quantity = 3 });
            this.ProductCartList.Add(new ProductCart { ProductCode = ProductsList[2].Code, SelectedDelivery = ProductsList[2].ShippingDeliveryType, Store = StoresList[2], Quantity = 7 });
            this.ProductCartList.Add(new ProductCart { ProductCode = ProductsList[0].Code, SelectedDelivery = ProductsList[0].ShippingDeliveryType, Store = StoresList[0], Quantity = 15 });

            this.CartsList.Add(new Cart() { Username = "user1", ListPC = ProductCartList});
            this.CartsList.Add(new Cart() { Username = "user2", ListPC = new List<ProductCart>() });
            this.CartsList.Add(new Cart() { Username = "user3", ListPC = new List<ProductCart>() });
            this.CartsList.Add(new Cart() { Username = "user4", ListPC = new List<ProductCart>() });
            this.CartsList.Add(new Cart() { Username = "user5", ListPC = new List<ProductCart>() });
        }

        public static SuperDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SuperDB();
                }
                return _instance;
            }
        }

        public List<Cart> CartsList { get; private set; }
        public List<Category> CategorysList { get; private set; }
        public List<Product> ProductsList { get; private set; }
        public List<ShippingAddress> ShippingAddressesList { get; private set; }
        public List<Store> StoresList { get; private set; }
        public List<User> UsersList { get; private set; }
        public List<ProductCart> ProductCartList { get; private set; }

    }
}
