using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Please Leave Your blog title!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Please do not leave the blog content!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Please do not leave the blog file path image!");
            //RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Please do not leave the blog Thumbnail image!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Please enter data less than 150 characters!");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Please enter data more than 4 characters!");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Please enter data more than 4 characters!");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Category cannot be empty!");
        }
    }
}
