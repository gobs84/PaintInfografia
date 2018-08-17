using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class StoreService : IService1<Store>
    {
        public SuperDB instance;
        public StoreService()
        {
            instance = SuperDB.Instance;
        }
        public int GetIndex(string key)
        {
            return instance.StoresList.FindIndex((x => x.Name == key));
        }

        public bool Verification(Store store)
        {
            return instance.StoresList.Exists((x => x.Name == store.Name));
        }

        public bool Create(Store store)
        {
            bool existe = !Verification(store);
            if (existe)
            {
                instance.StoresList.Add(store);
            }
            return existe;
        }
        public List<Store> Read()
        {
            return instance.StoresList;
        }
        public bool Update(string name, Store store)
        {
            int index = GetIndex(name);
            bool existe = true;
            if (!name.Equals(store.Name))
            {
                if (GetIndex(store.Name) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.StoresList[index] = store;
                else
                    existe = false;
            }
            return existe;
        }
        public bool Delete(string name)
        {
            bool eliminado = true;
            int index = GetIndex(name);
            if (index != -1)
                instance.StoresList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}