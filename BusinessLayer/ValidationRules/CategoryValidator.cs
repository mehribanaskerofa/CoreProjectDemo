using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Please do not leave the category name blank!")
               .MinimumLength(2).WithMessage("Please Enter Data More Than 2 Characters!")
               .MaximumLength(50).WithMessage("Please Enter Data Less Than 50 Characters!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Please do not leave the category description blank!");

        }
    }
}
