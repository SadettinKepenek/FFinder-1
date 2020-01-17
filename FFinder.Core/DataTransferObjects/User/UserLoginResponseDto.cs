using System;

namespace FFinder.Core.DataTransferObjects.User
{
    public class UserLoginResponseDto
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public string Username { get; set; }
        public string Id { get; set; }
    }
}