using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class Singer : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<SingerBranch> Branches { get; set; }

        public Singer()
        {
            Branches = new List<SingerBranch>();
        }

    }
}
