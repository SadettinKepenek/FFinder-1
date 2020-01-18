using FFinder.Core.DataTransferObjects.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Validators.Comment
{
    public class UpdateCommentValidator : AbstractValidator<CommentUpdateDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.CommentId).NotNull().NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.CommentBody).NotNull().NotEmpty().WithMessage("Yorum içeriği belirtilmelidir.");
            RuleFor(x => x.CommentBody).MaximumLength(250)
                    .WithMessage("Yorum içeriği maksimum 250 karakterden oluşmalıdır");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("PostId belirtilmelidir.");
            RuleFor(x => x.CommentDate).NotNull().NotEmpty().WithMessage("CommentDate belirtilmelidir.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("Yorumun aktiflik durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("OwnerId belirtilmelidir.");

        }


    }
}
