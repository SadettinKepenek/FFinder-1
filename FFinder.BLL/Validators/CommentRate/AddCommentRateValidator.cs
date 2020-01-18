using FFinder.Core.DataTransferObjects.CommentRate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Validators.CommentRate
{
    public class AddCommentRateValidator:AbstractValidator<CommentRateAddDto>
    {
        public AddCommentRateValidator()
        {
            RuleFor(x => x.CommentId).NotNull().NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.IsLike).NotNull().WithMessage("Yoruma like atılıp atılmadığı belirtilmelidir.");
            RuleFor(x => x.RateDate).NotNull().NotEmpty().WithMessage("Rate'e ait date belirtilmelidir.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("Yorumun aktiflik durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("OwnerId belirtilmelidir.");
        }
    }
}
