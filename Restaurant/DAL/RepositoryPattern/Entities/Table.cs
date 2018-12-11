using DAL.RepositoryPattern.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class Table : EntityBase
    {
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public int Capacity { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }

        public Table()
        {
            Reserves = new List<Reserve>();
        }
    }
}
