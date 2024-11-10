using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   public class Chugim:BaseEntity
    {
      
        public Chugim() 
        {
        }

        public Chugim(int kod_lesson, gauides kod_guaid, typ_chugim kod_typLesson, category kod_category, int min_atendance, int max_atendance, string day_lesson, DateTime hour_lesson, string status) 
        {
            this.kod_lesson = kod_lesson;
            this.kod_guaid = kod_guaid;
            this.kod_typLesson = kod_typLesson;
            this.kod_category = kod_category;
            this.min_atendance = min_atendance;
            this.max_atendance = max_atendance;
            this.day_lesson = day_lesson;
            this.hour_lesson = hour_lesson;
            this.status = status;
        }
        
        public int kod_lesson { get; set; }
        public gauides kod_guaid { get; set; }
        public typ_chugim kod_typLesson { get; set; }
        public category kod_category { get; set; }
        public int min_atendance { get; set; }
        public int max_atendance { get; set; }
        public string day_lesson { get; set; }
        public DateTime hour_lesson { get; set; }
        public string status { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_lesson" };
        }

        public override string GetTableName()
        {
            return "Chugim";
        }

        public override string ToString()
        {
            return hour_lesson+day_lesson+status+max_atendance+min_atendance;
        }
    }
}

