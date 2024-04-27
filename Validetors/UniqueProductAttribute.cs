using Final_Project.Models;
using Final_Project.Models.Entites;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Validetors
{
    public class UniqueProductAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string str = value.ToString();
            Company Db = new Company();
            Product proFromDB = Db.Products.FirstOrDefault(x => x.Name == str);

            if (proFromDB == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Already Exist");
            }

        }
    }
}
