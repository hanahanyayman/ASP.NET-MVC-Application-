using Final_Project.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Models
{
    [ModelMetadataType(typeof(AdminMetaData))]
    public class Admin
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
