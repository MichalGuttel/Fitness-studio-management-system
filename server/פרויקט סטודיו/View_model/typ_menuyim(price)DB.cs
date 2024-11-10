using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class Typ_menuyimDB:BaseDB
    {
        public Typ_menuyimDB() : base("typ_menuyim")
        {
        }
        public List<typ_menuyim_price_> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<typ_menuyim_price_>().ToList();
        }
        public typ_menuyim_price_ Gettyp_menuyim_price_ByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_typmanui == code);
        }

        protected override string CreatedeletedCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreateInsertCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity CreateModel()
        {
            typ_menuyim_price_  typ_Menuyim_Price = new typ_menuyim_price_();
            typ_Menuyim_Price.kod_typmanui = (int)reader["kod_typmanui"];
            typ_Menuyim_Price.numLesson_week = (int)reader["numLesson_week"];
            typ_Menuyim_Price.num_month= (int)reader["num_month"];
            typ_Menuyim_Price.prise = (int)reader["prise"];
            return typ_Menuyim_Price;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
