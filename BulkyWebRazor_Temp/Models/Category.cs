using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWebRazor_Temp.Model
{
    public class Category
    {
            [Key]//data annotation to assign the following variable as a primary key
            public int ID { get; set; }
            [Required]//data annotation to assign the following variable as "not null"
            [MaxLength(30)]//server side validation
            [DisplayName("Category Name")]//this data annotation indicates what we want to be displayed when this is called in html files 
            public string Name { get; set; }
            [DisplayName("Display Order")]
            [Range(1, 100, ErrorMessage = "Number must be between 1 and 100")]//server side validation. add the error msg urself if u want to customize it
            public int DisplayOrder { get; set; }

    }
    
}
