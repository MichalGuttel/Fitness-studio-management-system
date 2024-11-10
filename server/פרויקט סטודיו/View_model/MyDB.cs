using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_model
{
  public  class MyDB
    {
        public static CastumeresDB castumeres = new CastumeresDB();
        public static CategoryDB category = new CategoryDB();
        public static ChugimDB chugim = new ChugimDB();
        public static CityDB city = new CityDB();
        public static GauidesDB gauides = new GauidesDB();
        public static MenuyimDB menuyim = new MenuyimDB();
        public static Rishum_to_lessonDB rishum_To_Lesson = new Rishum_to_lessonDB();
        public static Typ_chugimDB Typ_Chugim = new Typ_chugimDB();
        public static Typ_menuyimDB Typ_menuyim_price = new Typ_menuyimDB();
        public static  VacationDB vacation = new VacationDB();
    }
}
