using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Final_Project.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Models
{
    [ModelMetadataType(typeof(ProductCardMetaData))]
    public class ProductsCard
    {
        public int Id { get; set; }
        [DisplayName("Card Id")]
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual Card? Card { get; set; }

        [DisplayName("Product Id")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int Quatity { get; set; }

        public int RemainingQuatity { get; set; }

        public bool isValid { get; set; } = true;
    }
}
