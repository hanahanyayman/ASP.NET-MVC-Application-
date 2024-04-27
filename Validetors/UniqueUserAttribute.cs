using Final_Project.Models.Entites;
using Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Validetors
{
    public class UniqueUserAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string str = value.ToString();
            Company Db = new Company();
            User userFromDB = Db.Users.FirstOrDefault(x => x.Name == str);

            if (userFromDB == null)
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
