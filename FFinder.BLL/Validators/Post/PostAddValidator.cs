using System;
using FFinder.Core.DataTransferObjects.Post;
using FluentValidation;

namespace FFinder.BLL.Validators.Post
{
    public class PostAddValidator : AbstractValidator<PostAddDto>
    {
        public PostAddValidator()
        {
            RuleFor(x => x.IsActive).NotNull().WithMessage("Aktiflik durumu boş geçilemez");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Kullanıcı Id'si boş geçilemez");
            RuleFor(x => x.PostBody).NotNull().NotEmpty().WithMessage("Mesaj içeriği ve Resim boş geçilemez.En az birisi dolu olmalıdır.").When(x => String.IsNullOrEmpty(x.PostImageUrl));
            RuleFor(x => x.PostImageUrl).NotNull().NotEmpty().WithMessage("Mesaj içeriği ve Resim boş geçilemez.En az birisi dolu olmalıdır.").When(x => String.IsNullOrEmpty(x.PostBody));
            RuleFor(x => x.PublishDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddMinutes(-5)).WithMessage("Paylaşım tarihi bugünden büyük olmalıdır.");
        }
    }
}