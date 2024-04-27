using Final_Project.MetaData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Final_Project.Models
{
    [ModelMetadataType(typeof(UserMetaData))]
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ProductsCard> Users { get; set; } = new HashSet<ProductsCard>();
    }
}
