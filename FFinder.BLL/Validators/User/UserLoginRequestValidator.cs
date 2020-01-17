using FFinder.Core.DataTransferObjects.User;
using FluentValidation;

namespace FFinder.BLL.Validators.User
{
    public class UserLoginRequestValidator:AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}