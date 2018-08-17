using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class CartService : IService1<Cart>
    {
        public SuperDB instance;
        public CartService()
        {
            instance = SuperDB.Instance;
        }
        public int GetIndex(string Username)
        {
            return instance.CartsList.FindIndex((x => x.Username == Username));
        }

        public bool Verification(Cart c)
        {
            return instance.CartsList.Exists((x => x.Username == c.Username));
        }

        public bool Create(Cart cart)
        {
            bool existe = !Verification(cart);
            if (existe)
            {
                instance.CartsList.Add(cart);
            }
            return existe;
        }

        public List<Cart> Read()
        {
            return instance.CartsList;
        }

        public bool Update(string key, Cart cart)
        {
            int index = GetIndex(key);
            bool existe = true;
            if (!key.Equals(cart.Username))
            {
                if (GetIndex(cart.Username) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.CartsList[index] = cart;
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
                instance.CartsList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
