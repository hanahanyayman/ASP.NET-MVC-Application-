using Final_Project.Validetors;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.MetaData
{
    public class ProductMetaData
    {
        [MinLength(3, ErrorMessage = "Name must be more than 3 char.")]
        [MaxLength(20, ErrorMessage = "Name must be less than 3 char.")]
        [UniqueProduct]
        public string Name { get; set; }

        [RegularExpression(@"\w*\.(jpg|png)", ErrorMessage = "Image must end with .png OR .jpg")]
        public string Image { get; set; }
    }
}
