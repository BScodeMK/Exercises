using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ogani.Data.Entities
{
    [Table("tbl_categories")]
    public class Category
    {
        public Category()
        {
            CategoryID = new Guid();
            CategoryName = String.Empty;
            CategoryDescription = String.Empty;
        }

        public Category(string categoryName, string categoryDescription)
        {
            CategoryID = new Guid();
            CategoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
            CategoryDescription = categoryDescription ?? throw new ArgumentNullException(nameof(categoryDescription));
        }

        [Key]
        public Guid CategoryID { get; set; }

        [StringLength(150, ErrorMessage = "Category name to long. Must be less then 150 characters!")]
        public string CategoryName { get; set; }


        [StringLength(500, ErrorMessage = "Category description  to long. Must be less then 500 characters!")]
        public string CategoryDescription { get; set; }

        
    }
}
