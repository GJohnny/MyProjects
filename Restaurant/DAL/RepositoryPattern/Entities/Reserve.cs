using DAL.RepositoryPattern.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class Reserve:EntityBase
    {
        public virtual Table Table { get; set; }
        public int TableId { get; set; }
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
        
    }
}
