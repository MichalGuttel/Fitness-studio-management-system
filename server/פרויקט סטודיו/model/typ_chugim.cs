using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   public class typ_chugim:BaseEntity
    {
        public typ_chugim() 
        {
        }

        public typ_chugim(string name_lesson, int kod_typLesson) 
        {
            this.name_lesson = name_lesson;
            this.kod_typLesson = kod_typLesson;
        }
        public string name_lesson { get; set; }
        public int kod_typLesson { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_typLesson" };
        }

        public override string GetTableName()
        {
            return "typ_chugim";
        }

        public override string ToString()
        {
            return name_lesson;
        }
    }
}

