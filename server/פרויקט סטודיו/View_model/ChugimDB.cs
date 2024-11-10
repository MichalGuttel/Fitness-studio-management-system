using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class ChugimDB:BaseDB
    {
        public ChugimDB() : base("Chugim")
        {
        }
        public List<Chugim> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<Chugim>().ToList();
        }
        public Chugim GetChugimByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_lesson == code);
        }
        protected override BaseEntity CreateModel()
        {
            Chugim chugim = new Chugim();
            chugim.kod_lesson = (int)reader["kod_lesson"];
            chugim.kod_guaid = MyDB.gauides.GetgauidesByCode((int)reader["kod_guaid"]);
            chugim.kod_typLesson = MyDB.Typ_Chugim.Gettyp_chugimByCode((int)reader["kod_typLesson"]);
            chugim.kod_category = MyDB.category.GetcategoryByCode((int)reader["kod_category"]);
            chugim.min_atendance = (int)reader["min_atendance"];
            chugim.max_atendance = (int)reader["max_atendance"];
            chugim.day_lesson = reader["day_lesson"].ToString();
            chugim.hour_lesson = Convert.ToDateTime(reader["hour_lesson"]);
            chugim.status = reader["status"].ToString();
             return chugim;
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
