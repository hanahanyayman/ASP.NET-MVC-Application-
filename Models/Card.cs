using Final_Project.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Models
{
    [ModelMetadataType(typeof(CardMetaData))]
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
