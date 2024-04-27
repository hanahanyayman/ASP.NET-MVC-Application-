using Final_Project.Validetors;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.MetaData
{
    public class AdminMetaData
    {
        [MinLength(3, ErrorMessage = "Name must be more than 3 char.")]
        [MaxLength(20, ErrorMessage = "Name must be less than 3 char.")]
        [UniqueAdmin]
        public string Name { get; set; }

        [Range(22, 35)]
        public int Age { get; set; }
    }
}
