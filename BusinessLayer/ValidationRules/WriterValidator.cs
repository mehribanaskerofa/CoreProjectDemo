using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Please do not leave the Author's Name Surname blank!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Please do not leave the Email Address field blank!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Password cannot be blank!");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Your password must contain at least one lowercase letter and one uppercase letter and number!");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
