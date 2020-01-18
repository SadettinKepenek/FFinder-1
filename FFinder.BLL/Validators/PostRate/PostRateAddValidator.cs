using System;
using FFinder.Core.DataTransferObjects.PostRate;
using FluentValidation;

namespace FFinder.BLL.Validators.PostRate
{
    public class PostRateAddValidator:AbstractValidator<PostRateAddDto>
    {
        public PostRateAddValidator()
        {
            RuleFor(x => x.IsActive).NotNull().WithMessage("Aktiflik durumu boş geçilemez");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Kullanıcı Id'si boş geçilemez");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("Post Id boş geçilemez");
            RuleFor(x => x.IsLike).NotNull().WithMessage("Like yada Dislike seçilmelidir");
            RuleFor(x => x.RateDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddMinutes(-5))
                .WithMessage("Beğeni tarihi bugün veya daha ilerisi olabilir");
        }
    }
}