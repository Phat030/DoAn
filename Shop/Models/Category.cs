using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int IDCategory { get; set; }
        [Required]
        public string NameCate { get; set; }

        public ICollection<Product> Product { get; set; }
        [NotMapped]
        public List<Category> CateCollection { get; set; }
    }
}