using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    //  we can create tables using entity framework (ORM) 
    public class Category
    {
        // enter all the columns u want in the table category 
        [Key]
        public int Id { get; set; }   // primary key
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
