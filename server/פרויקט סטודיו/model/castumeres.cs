using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class castumeres : BaseEntity
    {

        public castumeres()
        {
        }

        public castumeres(string id_castumer, string private_name, string family_name, string adresse, DateTime date_birth, string pelephone, string mail, city kod_city, category kod_category)
        {
            this.id_castumer = id_castumer;
            this.private_name = private_name;
            this.family_name = family_name;
            this.adresse = adresse;
            this.date_birth = date_birth;
            this.pelephone = pelephone;
            this.mail = mail;
            this.kod_city = kod_city;
            this.kod_category = kod_category;

        }

        public string id_castumer { get; set; }
        public string private_name { get; set; }
        public string family_name { get; set; }
        public string adresse { get; set; }
        public DateTime date_birth { get; set; }
        public string pelephone { get; set; }
        public string mail { get; set; }
        public city kod_city { get; set; }
        public category kod_category { get; set; }



        public override string[] GetKeyFields()
        {
            return new string[] { "id_castumer" };
        }

        public override string GetTableName()
        {
          return "castumeres";
        }

        public override string ToString()
        {
            return id_castumer+private_name+family_name+adresse+date_birth+pelephone+mail;
        }
    }
}

