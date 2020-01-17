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
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId belirtilmelidir.");
            RuleFor(x => x.CommentBody).NotEmpty().WithMessage("Yorum içeriği belirtilmelidir.");
            RuleFor(x => x.CommentBody).MaximumLength(250)
                    .WithMessage("Yorum içeriği maksimum 250 karakterden oluşmalıdır");
            RuleFor(x => x.PostId).NotEmpty().WithMessage("PostId belirtilmelidir.");
            RuleFor(x => x.CommentDate).NotEmpty().WithMessage("CommentDate belirtilmelidir.");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Yorumun aktiflik durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId belirtilmelidir.");

        }


    }
}
