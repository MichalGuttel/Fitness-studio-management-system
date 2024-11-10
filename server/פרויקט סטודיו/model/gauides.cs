using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
  public class gauides:BaseEntity
    {  public gauides()
        { }
        public gauides(int kod_guaid, string name_guaid, string family_guaid, string adresse_guaid, city kod_city, string tel_guaid, DateTime dateBirth_guaid, int vetek)
        {
            this.kod_guaid = kod_guaid;
            this.name_guaid = name_guaid;
            this.family_guaid = family_guaid;
            this.adresse_guaid = adresse_guaid;
            this.kod_city = kod_city;
            this.tel_guaid = tel_guaid;
            this.dateBirth_guaid = dateBirth_guaid;
            this.vetek = vetek;
        }
        public int kod_guaid { get; set; }
        public string name_guaid { get; set; }
        public string family_guaid { get; set; }
        public string adresse_guaid { get; set; }
        public city kod_city { get; set; }
        public string tel_guaid { get; set; }
        public DateTime dateBirth_guaid{ get; set; }
        public int vetek { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_guaid" };
        }
        public override string GetTableName()
        {
           return "gauides";
        }

        public override string ToString()
        {
            return name_guaid+family_guaid+adresse_guaid+tel_guaid+dateBirth_guaid+vetek;
        }
    }
}

