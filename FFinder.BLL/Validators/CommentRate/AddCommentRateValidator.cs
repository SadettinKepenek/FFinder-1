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
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.IsLike).NotEmpty().WithMessage("Yoruma like atılıp atılmadığı belirtilmelidir.");
            RuleFor(x => x.RateDate).NotEmpty().WithMessage("Rate'e ait date belirtilmelidir.");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Yorumun aktiflik durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId belirtilmelidir.");
        }
    }
}
