using FFinder.Core.DataTransferObjects.CommentRate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Validators.CommentRate
{
    public class UpdateCommentRateValidator:AbstractValidator<CommentRateUpdateDto>
    {
        public UpdateCommentRateValidator()
        {
            RuleFor(x => x.CommentRateId).NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.IsLike).NotNull().WithMessage("Yoruma like atılıp atılmadığı belirtilmelidir.");
            RuleFor(x => x.RateDate).NotEmpty().WithMessage("Rate'e ait date belirtilmelidir.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("Yorumun aktiflik durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId belirtilmelidir.");
        }
    }
}
