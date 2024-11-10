using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class CityDB:BaseDB
    {
        public CityDB() : base("city")
        {
        }
        public List<city> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<city>().ToList();
        }
        public bool Checkcity(string ncity)
        {
            try
            {
                var g = GetList().FirstOrDefault(x => x.name_city == ncity);
                if (g != null)
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
        public city GetcityByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_city == code);
        }
        protected override BaseEntity CreateModel()
        {
            city city = new city();
            city.kod_city = (int)reader["kod_city"];
            city.name_city = reader["name_city"].ToString();
            return city;
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
