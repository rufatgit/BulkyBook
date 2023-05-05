
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;  //Key and Required

namespace BulkyBookWEB.Models
{
    public class Category
    {
        [Key]    //attribute           Data Annotations
        public int Id { get; set; } 
        [Required]   //attribute
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;




    }
}

