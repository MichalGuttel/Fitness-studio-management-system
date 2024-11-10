using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
   public class vacation:BaseEntity
    {
        public vacation() 
        {
        }

        public vacation(int kod_vocation, DateTime firstDate_vocation, DateTime lastDate_vocation, bool is_agree, menuyim kod_manui, string reason) 
        {
            this.kod_vocation = kod_vocation;
            this.firstDate_vocation = firstDate_vocation;
            this.lastDate_vocation = lastDate_vocation;
            this.is_agree = is_agree;
            this.kod_manui = kod_manui;
            this.reason = reason;
        }
        public int kod_vocation { get; set; }
        public DateTime firstDate_vocation { get; set; }
        public DateTime lastDate_vocation { get; set; }
        public bool is_agree { get; set; }
        public menuyim kod_manui { get; set; }
        public string reason { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "kod_vocation" };
        }

        public override string GetTableName()
        {
            return "vacation";
        }

        public override string ToString()
        {
            return reason + kod_manui;
        }
    }
}

