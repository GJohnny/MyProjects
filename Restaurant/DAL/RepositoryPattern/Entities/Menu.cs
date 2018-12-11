using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.RepositoryPattern.Entities
{
    public class Menu : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPopular { get; set; }
    }
}
