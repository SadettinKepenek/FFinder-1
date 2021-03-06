﻿using System;
using FFinder.Core.DataTransferObjects.Follower;
using FluentValidation;

namespace FFinder.BLL.Validators.Follower
{
    public class FollowerUpdateValidator:AbstractValidator<FollowerUpdateDto>
    {
        public FollowerUpdateValidator()
        {
            RuleFor(x => x.FollowerId).NotNull().NotEmpty().WithMessage("Takip Idsi boş geçilemez");
            RuleFor(x => x.User1Id).NotNull().NotEmpty().WithMessage("Takip isteğini gönderen boş geçilemez");
            RuleFor(x => x.User2Id).NotNull().NotEmpty().WithMessage("Takip isteği gönderilen boş geçilemez");
            RuleFor(x => x.FriendshipDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddMinutes(-5)).WithMessage("Takip isteği tarihi boş geçilemez ve bugüne eşit veya ileri olmalıdır");
            RuleFor(x => x.IsActive).NotNull().WithMessage("Aktiflik durumu boş geçilemez");
        }
    }
}