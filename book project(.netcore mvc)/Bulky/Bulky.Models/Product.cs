using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Models
{
    public class Product
    {
        [Key] // primary key
        public int Id { get; set; }
        [Required] // not null
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        // our website name is bulky web 
        // where we can books in bulk
        // if they get books in bulk they will get discount

        [Required]
        [DisplayName("List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        // cost of product for quantity 1-50
        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1, 1000)] // price should be in this range $1 - $1000
        public double Price { get; set; }

        // cost of product for quantity 50+
        [Required]
        [DisplayName("Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        // cost of product for quantity 100+
        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        // connecting to category table
        public int CategoryId { get; set; }
        //his is a navigation property to access the related Category object for a given product.
        //The [ForeignKey("CategoryId")] attribute explicitly tells EF Core to use CategoryId as the foreign key for the Category navigation property.
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        // image url for the product
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
