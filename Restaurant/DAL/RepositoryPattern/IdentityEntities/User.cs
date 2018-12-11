using DAL.RepositoryPattern.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.RepositoryPattern.IdentityEntities
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
        public User()
        {
            Reserves = new List<Reserve>();
        }
    }
}
