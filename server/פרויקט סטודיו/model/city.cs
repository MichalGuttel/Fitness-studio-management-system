using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class city:BaseEntity
    {
  
        public city() 
        {
        }
        public city(int kod_city, string name_city) 
        {
            this.kod_city = kod_city;
            this.name_city = name_city;
        }
        
        public int kod_city { get; set; }
        public string name_city { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_city" };
        }

        public override string GetTableName()
        {
            return "city";
        }

        public override string ToString()
        {
            return name_city;
        }
    }
}

