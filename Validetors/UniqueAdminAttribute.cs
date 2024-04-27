using Final_Project.Models.Entites;
using Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Validetors
{
    public class UniqueAdminAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string str = value.ToString();
            Company Db = new Company();
            Admin adminFromDB = Db.Admins.FirstOrDefault(x => x.Name == str);

            if (adminFromDB == null)
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
