using Final_Project.Validetors;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.MetaData
{
    public class CardMetaData
    {
        [MinLength(3, ErrorMessage = "Name must be more than 3 char.")]
        [MaxLength(20, ErrorMessage = "Name must be less than 3 char.")]
        [UniqueCard]
        public string Name { get; set; }
    }
}
