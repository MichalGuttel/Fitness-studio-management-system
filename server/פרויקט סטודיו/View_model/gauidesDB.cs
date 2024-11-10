  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class GauidesDB:BaseDB
    {
        public GauidesDB() : base("gauides")
        {
        }
        public List<gauides> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<gauides>().ToList();
        }
        public gauides GetgauidesByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_guaid == code);
        }
        protected override BaseEntity CreateModel()
        {
            gauides gauides = new gauides();
            gauides.kod_guaid = (int)reader["kod_guaid"];
            gauides.name_guaid = reader["name_guaid"].ToString();
            gauides.family_guaid =reader["family_guaid"].ToString();
            gauides.adresse_guaid =reader["adresse_guaid"].ToString();
            gauides.kod_city = MyDB.city.GetcityByCode((int)reader["kod_city"]);
            gauides.tel_guaid = reader["tel_guaid"].ToString();
            gauides.dateBirth_guaid = Convert.ToDateTime(reader["dateBirth_guaid"]);
            gauides.vetek = (int)reader["vetek"];
            return gauides;
        }

        protected override string CreateInsertCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }

        protected override string CreatedeletedCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
