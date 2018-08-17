using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class User : IEquatable<User>
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public List<ShippingAddress> ShippingAddresses { get; set; }
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.Name = "";
            this.LastName = "";
            this.ShippingAddresses = new List<ShippingAddress>();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Username == other.Username;
        }

        public override int GetHashCode()
        {
            return -182246463 + EqualityComparer<string>.Default.GetHashCode(Username);
        }
    }
}
