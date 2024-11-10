using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class Rishum_to_lessonDB:BaseDB
    {
        public Rishum_to_lessonDB() : base("rishum_to_lesson")
        {
        }
        public List<rishum_to_lesson> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<rishum_to_lesson>().ToList();
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
           rishum_to_lesson rishum_to_Lesson = new rishum_to_lesson();
          rishum_to_Lesson.kod_manui = MyDB.menuyim.GetmenuyimByCode((int)reader["kod_manui"]);
          rishum_to_Lesson.kod_lesson = MyDB.chugim.GetChugimByCode((int)reader["kod_lesson"]);
          rishum_to_Lesson.date_rishum = Convert.ToDateTime(reader["date_rishum"]);
          rishum_to_Lesson.is_perfumence = (bool)reader["is_perfumence"];
          rishum_to_Lesson.is_mustPay = (bool)reader["is_mustPay"];
            return rishum_to_Lesson ;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
