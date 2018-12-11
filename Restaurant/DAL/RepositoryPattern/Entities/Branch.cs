using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class Branch : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<SingerBranch> Singers { get; set; }
        public Branch()
        {
            Tables = new List<Table>();
            Singers = new List<SingerBranch>();
        }
    }
}
