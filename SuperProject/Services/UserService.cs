using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject.Services
{
    public class UserService : IService1<User>
    {
        public SuperDB instance;
        public UserService()
        {
            instance = SuperDB.Instance;
        }

        public int GetIndex(string key)
        {
            return instance.UsersList.FindIndex((x => x.Username == key));
        }

        public bool Verification(User u)
        {
            return instance.UsersList.Exists((x => x.Username == u.Username));
        }

        public bool Create(User user)
        {
            bool existe = false;
            if (!instance.UsersList.Contains(user))
            {
                instance.UsersList.Add(user);
                existe = true;
            }
            return existe;
        }
        public List<User> Read()
        {
            return instance.UsersList;
        }
        public bool Update(string key, User user)
        {
            int index = GetIndex(key);
            bool existe = true;
            if (!key.Equals(user.Username))
            {
                if (GetIndex(user.Username) != -1)
                    existe = false;
                else
                    existe = true;
            }
            if (existe)
            {
                if (index != -1)
                    instance.UsersList[index] = user;
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
                instance.UsersList.RemoveAt(index);
            else
                eliminado = false;
            return eliminado;
        }
    }
}
