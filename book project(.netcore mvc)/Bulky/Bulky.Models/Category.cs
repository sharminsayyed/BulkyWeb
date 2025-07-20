using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky_Models
{
    //  we can create tables using entity framework (ORM) 
    public class Category
    {
        // enter all the columns u want in the table category 
        [Key]// these are called as data annotation
        public int Id { get; set; }   // primary key
        [Required]// not null
        [MaxLength(30)] // validations
        [DisplayName("Category Name")] // how to display the column when called 
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100 ")]// validations
        public int DisplayOrder { get; set; }
    }
}
