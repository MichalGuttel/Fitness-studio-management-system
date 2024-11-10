using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class VacationDB : BaseDB
    {
        public VacationDB() : base("vacation") 
        { 
        }
        public List<vacation> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<vacation>().ToList();
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
            vacation vacation = new vacation();
            vacation.kod_vocation = (int)reader["kod_vocation"];
            vacation.firstDate_vocation = Convert.ToDateTime(reader["firstDate_vocation"]);
            vacation.lastDate_vocation = Convert.ToDateTime(reader["lastDate_vocation"]);
            vacation.is_agree = (bool)reader["is_agree"];
            vacation.kod_manui = MyDB.menuyim.GetmenuyimByCode((int)reader["kod_manui"]);
            vacation.reason = reader["reason"].ToString();
            return vacation;
       }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
