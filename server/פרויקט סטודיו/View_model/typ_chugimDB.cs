using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class Typ_chugimDB:BaseDB
    {
        public Typ_chugimDB() : base("typ_chugim")
        {
        }
        public List<typ_chugim> GetList()
        {
            if (list.Count() == 0)
            {
                Select();
            }
            return list.Cast<typ_chugim>().ToList();
        }
        public typ_chugim Gettyp_chugimByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_typLesson == code);
        }
    
        public bool Checktypch(string namech)
        {
            try
            {
                var g = GetList().FirstOrDefault(x => x.name_lesson== namech);
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
           typ_chugim typ_Chugim= new typ_chugim();
            typ_Chugim.name_lesson = reader["name_lesson"].ToString();
            typ_Chugim.kod_typLesson = (int)reader["kod_typLesson"];
            return typ_Chugim;
        }

        protected override string CreateUpdateCommand(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
