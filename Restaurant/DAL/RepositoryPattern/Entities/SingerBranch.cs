using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class SingerBranch : EntityBase
    {
        public virtual Singer Singer { get; set; }
        public int SingerId { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }

    }
}
