using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class Store
    {
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Phone { get; set; }

        public Store()
        {
            this.Name = "";
            this.Line1 = "";
            this.Line2 = "";
            this.Phone = 0;
        }
    }
}
