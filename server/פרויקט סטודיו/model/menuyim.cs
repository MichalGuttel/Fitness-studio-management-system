using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    
   public class menuyim:BaseEntity
    {
        public menuyim() 
        {
        }

        public menuyim(int kod_manui, castumeres id_castumer, typ_menuyim_price_ kod_typmanui, bool Ispay, DateTime first_date, DateTime last_date) 
        {
            this.kod_manui = kod_manui;
            this.id_castumer = id_castumer;
            this.kod_typmanui = kod_typmanui;
            this.Ispay = Ispay;
            this.first_date = first_date;
            this.last_date = last_date;
        }
        public int kod_manui { get; set; }
        public castumeres id_castumer { get; set; }
        public typ_menuyim_price_ kod_typmanui { get; set; }
        public bool Ispay { get; set; }
        public DateTime first_date { get; set; }
        public DateTime last_date { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_manui" };
        }

        public override string GetTableName()
        {
            return "menuyim";
        }

        public override string ToString()
        {
            return first_date.ToString()+last_date.ToString()+Ispay+id_castumer.ToString();
        }
    }
}
