using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Final_Project.MetaData;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Final_Project.Models
{
    [ModelMetadataType(typeof(ProductMetaData))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
