using Final_Project.Models.Entites;
using Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Validetors
{
    public class UniqueCardAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string str = value.ToString();
            Company Db = new Company();
            Card cardFromDB = Db.Cards.FirstOrDefault(x => x.Name == str);

            if (cardFromDB == null)
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
