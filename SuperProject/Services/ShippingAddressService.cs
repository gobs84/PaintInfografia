using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class ShippingAddressService : IService1<ShippingAddress>
    {
        public SuperDB instance;
        public ShippingAddressService()
        {
            instance = SuperDB.Instance;
        }

        public int GetIndex(string key)
        {
            return instance.ShippingAddressesList.FindIndex((x => x.Identifier == key));
        }

        public bool Verification(ShippingAddress s)
        {
            return instance.ShippingAddressesList.Exists((x => x.Identifier == s.Identifier));
        }

        public bool Create(ShippingAddress newSA)
        {
            bool existe = !Verification(newSA);
            if (existe)
            {
                instance.ShippingAddressesList.Add(newSA);
            }
            return existe;
        }
        public List<ShippingAddress> Read()
        {
            return instance.ShippingAddressesList;
        }
        public bool Update(string key, ShippingAddress actualizado)
        {
            int index = GetIndex(key);
            bool existe = true;
            if (!key.Equals(actualizado.Identifier))
            {
                if (GetIndex(actualizado.Identifier) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.ShippingAddressesList[index] = actualizado;
                else
                    existe = false;
            }
            return existe;
        }
        public bool Delete(string key)
        {
            bool eliminado = true;
            int index = GetIndex(key);
            if (index != -1)
                instance.ShippingAddressesList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
