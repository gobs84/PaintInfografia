using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProject.Services
{
   public class ProductCartService : IService1<ProductCart>
    {
        public SuperDB instance;
        public ProductCartService() {
            instance = SuperDB.Instance;
        }
        public int GetProductCartIndex(string productCode)
        {
            return instance.ProductCartList.FindIndex((x => x.ProductCode == productCode));
        }

        public bool ProductCartVerification(ProductCart pc)
        {
            return instance.ProductCartList.Exists((x => x.ProductCode == pc.ProductCode));
        }


        public bool Create(ProductCart pc)
        {
            bool existe = !ProductCartVerification(pc);
            if (existe)
            {
                if (!pc.SelectedDelivery.Equals("inStore"))
                    pc.Store = null;
                instance.ProductCartList.Add(pc);
            }
            return existe;
        }
        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetProductCartIndex(key);
            if (index != -1)
                instance.ProductCartList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
        public List<ProductCart> Read()
        {
            return instance.ProductCartList;
        }

        public bool Update(string key, ProductCart pc)
        {
            int index = GetProductCartIndex(key);
            bool existe = true;
            if (!key.Equals(pc.ProductCode))
            {
                if (GetProductCartIndex(pc.ProductCode) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.ProductCartList[index] = pc;
                else
                    existe = false;
            }
            return existe;
        }

    }
}
