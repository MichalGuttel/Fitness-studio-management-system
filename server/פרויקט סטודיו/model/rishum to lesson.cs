using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   
   public class rishum_to_lesson:BaseEntity
    {
        public rishum_to_lesson() 
        {
        }

        public rishum_to_lesson(menuyim kod_manui, Chugim kod_lesson, DateTime date_rishum, bool is_perfumence, bool is_mustPay) 
        {
            this.kod_manui = kod_manui;
            this.kod_lesson = kod_lesson;
            this.date_rishum = date_rishum;
            this.is_perfumence = is_perfumence;
            this.is_mustPay = is_mustPay;
        }
        public menuyim kod_manui { get; set; }
        public Chugim kod_lesson { get; set; }
        public DateTime date_rishum { get; set; }
        public bool is_perfumence { get; set; }
        public bool is_mustPay { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_manui","kod_lesson","date_rishum" };
        }

        public override string GetTableName()
        {
            return "rishum to lesson";
        }

        public override string ToString()
        {
            return date_rishum.ToString()+is_mustPay.ToString()+is_perfumence;
        }
    }
}

