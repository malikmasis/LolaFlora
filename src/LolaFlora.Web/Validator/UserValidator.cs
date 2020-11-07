using FluentValidation;
using LolaFlora.Data.Entities;

namespace LolaFlora.Web.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 10).WithMessage("name could not be null");
            RuleFor(x => x.Username).NotNull().WithMessage("This player out of staff");
            RuleFor(x => x.Email).MinimumLength(3).MaximumLength(50).WithMessage("Mail character length is invalid");
        }
    }
}
