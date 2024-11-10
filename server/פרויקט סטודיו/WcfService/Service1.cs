 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using model;
using View_model;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "." menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool CheckCastumerIfExist(string id)
        {
            try
            {
                return MyDB.castumeres.CheckC(id);
            }
            catch
            {
                return false;
            }
        }

        public bool Checkchugifexcist(string namech)
        {
            try
            {
                return MyDB.Typ_Chugim.Checktypch(namech);
            }
            catch
            {
                return false;
            }
        }
        public  bool CheckcityIfExist(string ncity)
        {
            try
            {
                return MyDB.city.Checkcity(ncity);
            }
            catch
            {
                return false;
            }
        }
        public castumeres GetCustById(string id)
        {
            return MyDB.castumeres.GetcastumeresById(id);
        }

        public List<castumeres> GetAllCastumeres()
        {
            List<castumeres> c = MyDB.castumeres.GetList();
            return c;
        }
        public List<menuyim> GetManuyToCust(castumeres id)
        {
            List<menuyim> m = new List<menuyim>();
            m = MyDB.menuyim.GetList().Where(x => x.id_castumer == id).ToList();
            return m;
        }

        public int AddCastumer(castumeres s)
        {
            MyDB.castumeres.Add(s);
         return MyDB.castumeres.SaveChanges();
        }

        public void AddManui(menuyim n)
        {
            MyDB.menuyim.Add(n);
          MyDB.menuyim.SaveChanges();
        }

        public int GetCodtomenuyim()
        {
            if (MyDB.menuyim.GetList().Count == 0) return 1;
            return MyDB.menuyim.GetList().Max(x => x.kod_manui) + 1;
        }

         public int GetCodtotypmanuy()
        {
            if (MyDB.Typ_menuyim_price.GetList().Count == 0) return 1;
            return MyDB.Typ_menuyim_price.GetList().Max(x => x.kod_typmanui) + 1;
        }

        public int GetCodtocity() 
        {
            if (MyDB.city.GetList().Count == 0) return 1;
            return MyDB.city.GetList().Max(x => x.kod_city) + 1;
        }

        public int GetCodtotypchugim()
        {
            if (MyDB.Typ_Chugim.GetList().Count == 0) return 1;
            return MyDB.Typ_Chugim.GetList().Max(x => x.kod_typLesson) + 1;
        }

        public List<Chugim> GetAllChugim()
        {
            return MyDB.chugim.GetList();
        }
        public List<gauides> GetAllGauides()
        {
            return MyDB.gauides.GetList();
        }
        public List<rishum_to_lesson> GetLessonsInWeekForCustomer(int codeManuy)
        {
            //כל הרישומים לשבוע זה
   
            return MyDB.rishum_To_Lesson.GetList().Where(x => x.kod_manui.kod_manui == codeManuy && x.date_rishum >= DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)) && x.date_rishum <= DateTime.Today.AddDays(7 - (int)(DateTime.Today.DayOfWeek))).ToList();
        }
        public int GetNumLessonfree(int codeManuy)
        {
            //כמה שיעורים נשאר

            return MyDB.menuyim.GetmenuyimByCode(codeManuy).kod_typmanui.numLesson_week - MyDB.rishum_To_Lesson.GetList().Where(x => x.kod_manui.kod_manui == codeManuy && x.date_rishum >= DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)) && x.date_rishum <= DateTime.Today.AddDays(7 - (int)(DateTime.Today.DayOfWeek))).ToList().Count;
        }


        public menuyim GetManuy(int codeManuy)
        {
            return MyDB.menuyim.GetmenuyimByCode(codeManuy);
        }
      
        public List<city> GetAllcity()
        {
            return MyDB.city.GetList();
        }

        public List<category> GetAllcategory()
        {
            return MyDB.category.GetList();
        }
       public List<typ_menuyim_price_> GetAllTypmanui()
        {
            return MyDB.Typ_menuyim_price.GetList();
        }

        public int Addtypchug(typ_chugim t)
        {
            MyDB.Typ_Chugim.Add(t);
            return MyDB.Typ_Chugim.SaveChanges();
        }

         public List<typ_chugim>GetAllTyp_Chugims()
            {
                return MyDB.Typ_Chugim.GetList();
            }
        
         public List<rishum_to_lesson>GetAlrishum()
            {
                return MyDB.rishum_To_Lesson.GetList();
            }

        public int GetCodtogauid()
        {
            if (MyDB.gauides.GetList().Count == 0) return 1;
            return MyDB.gauides.GetList().Max(x => x.kod_guaid) + 1;
        }


        public int Addgauid(gauides g)
        {
            MyDB.gauides.Add(g);
            return MyDB.gauides.SaveChanges();
        }

        public int Addcity(city c)
        {
            MyDB.city.Add(c);
            return MyDB.city.SaveChanges();
        }

        public int Addtypmanui(typ_menuyim_price_ t)
        {
            MyDB.Typ_menuyim_price.Add(t);
            return MyDB.Typ_menuyim_price.SaveChanges();
        }

        public int Addlesson(Chugim c)
        {
            MyDB.chugim.Add(c);
            return MyDB.chugim.SaveChanges();
        }

        public int Addlesontomanui(rishum_to_lesson r)
        {
            MyDB.rishum_To_Lesson.Add(r);
            return MyDB.rishum_To_Lesson.SaveChanges();
        }
        public int delatguaid(gauides g)
        {
            MyDB.gauides.Deleted(g);
          return  MyDB.gauides.SaveChanges();
        }

        public int delate(castumeres c)
        {
            MyDB.castumeres.Deleted(c);
          return  MyDB.castumeres.SaveChanges();
        }
        public int delateciey(city c)
        {

            MyDB.city.Deleted(c);
           return MyDB.city.SaveChanges();
        }
        
        public int delatetypchug(typ_chugim t)
        {

            MyDB.Typ_Chugim.Deleted(t);
           return MyDB.Typ_Chugim.SaveChanges();
        }
    }
    }
