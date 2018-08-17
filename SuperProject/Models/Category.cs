using System;
using System.Collections.Generic;
using System.Text;

namespace SuperProject
{
    public class Category
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public Category()
        {
            this.Name = "";
            this.Description = "";
        }
    }
}
