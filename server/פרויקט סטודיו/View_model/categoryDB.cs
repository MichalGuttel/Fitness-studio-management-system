using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace View_model
{
   public class CategoryDB:BaseDB
    {
        public CategoryDB() : base("category")
        {
        }
        public List<category> GetList()
        {
            if(list.Count() == 0)
            {
                Select();
            }
            return list.Cast<category>().ToList();
        }
    
    public category GetcategoryByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.kod_category == code);
        }
        protected override BaseEntity CreateModel()
        {
            category category = new category();
            category.kod_category = (int)reader["kod_category"];
            category.name_category = reader["name_category"].ToString();
           return category;
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
