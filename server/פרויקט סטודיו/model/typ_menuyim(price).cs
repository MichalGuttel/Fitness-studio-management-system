using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   public class typ_menuyim_price_:BaseEntity
    {
        public typ_menuyim_price_() 
        {
        }

        public typ_menuyim_price_(int kod_typmanui, int prise,int numLesson_week, int num_month) 
        {
            this.kod_typmanui = kod_typmanui;
            this.prise = prise;
            this.numLesson_week = numLesson_week;
            this.num_month = num_month;
        }
        public int kod_typmanui { get; set; }
        public int prise { get; set; }
        public int numLesson_week { get; set; }
        public int num_month { get; set; }
        

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_typmanui" };
        }

        public override string GetTableName()
        {
            return "kod_typmanui";
        }

        public override string ToString()
        {
            return numLesson_week.ToString();
        }
    }
}
