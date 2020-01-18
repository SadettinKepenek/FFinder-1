using FFinder.Core.DataTransferObjects.User;
using FluentValidation;

namespace FFinder.BLL.Validators.User
{
    public class UserUpdateValidator:AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().WithMessage("Aktiflik durumu boş geçilemez");
            RuleFor(x => x.AboutMe).NotNull().NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez");
            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("Şehir kısmı boş geçilemez");
            RuleFor(x => x.Country).NotNull().NotEmpty().WithMessage("Ülke kısmı boş geçilemez");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email kısmı boş geçilemez");
            RuleFor(x => x.Firstname).NotNull().NotEmpty().WithMessage("Ad kısmı boş geçilemez");
            RuleFor(x => x.Lastname).NotNull().NotEmpty().WithMessage("Soyad kısmı boş geçilemez");
            RuleFor(x => x.Gender).NotNull().NotEmpty().WithMessage("Cinsiyet kısmı boş geçilemez");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Username kısmı boş geçilemez");
        }
    }
}