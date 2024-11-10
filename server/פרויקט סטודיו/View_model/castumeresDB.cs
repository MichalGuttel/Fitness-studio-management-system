using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
  public class CastumeresDB:BaseDB
    {
       public CastumeresDB():base("castumeres")
        {
        }
        public List<castumeres> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<castumeres>().ToList();
        }
        public castumeres GetcastumeresById(string id)
        {
            return GetList().FirstOrDefault(m => m.id_castumer == id);
        }
        public bool CheckC(string id)
        {
            try
            {
                var t = GetList().FirstOrDefault(x => x.id_castumer == id);
                if (t != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            }
        protected override BaseEntity CreateModel()
        {
           castumeres castumeres = new castumeres();
            castumeres.id_castumer = reader["id_castumer"].ToString();
            castumeres.private_name = reader["private_name"].ToString();
            castumeres.family_name = reader["family_name"].ToString();
            castumeres.adresse = reader["adresse"].ToString();
            castumeres.date_birth = Convert.ToDateTime(reader["date_birth"]);
            castumeres.pelephone = reader["pelephone"].ToString();
            castumeres.mail = reader["mail"].ToString();
            castumeres.kod_city = MyDB.city.GetcityByCode((int)reader["kod_city"]);
            castumeres.kod_category = MyDB.category.GetcategoryByCode((int)reader["kod_category"]);
            return castumeres;
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
