using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class MenuyimDB:BaseDB
    {
        public MenuyimDB() : base("menuyim")
        {
        }
        public List<menuyim> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<menuyim>().ToList();
        }
        public  menuyim GetmenuyimByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_manui == code);
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
            menuyim menuyim = new menuyim();
            menuyim.kod_manui = (int)reader["kod_manui"];
            menuyim.id_castumer = MyDB.castumeres.GetcastumeresById(reader["id_castumer"].ToString());
            menuyim.kod_typmanui = MyDB.Typ_menuyim_price.Gettyp_menuyim_price_ByCode((int)reader["kod_typmanui"]);
            menuyim.Ispay = (bool)reader["Ispay"];
            menuyim.first_date = Convert.ToDateTime(reader["first_date"]);
            menuyim.last_date = Convert.ToDateTime(reader["last_date"]);
            return menuyim;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
