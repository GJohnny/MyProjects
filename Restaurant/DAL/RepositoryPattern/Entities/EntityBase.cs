using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
