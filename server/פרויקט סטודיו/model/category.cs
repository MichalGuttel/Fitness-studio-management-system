using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   
   public class category:BaseEntity
    {
       
        public category() 
        {
        }

        public category(int kod_category, string name_category) 
        {
            this.kod_category = kod_category;
            this.name_category = name_category;
        }
         public int kod_category { get; set; }
        public string name_category { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_category" };
        }

        public override string GetTableName()
        {
            return "categoty";
        }

        public override string ToString()
        {
            return name_category;
        }
    }
}
