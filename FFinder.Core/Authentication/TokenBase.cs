using System;
using Microsoft.Extensions.Configuration;

namespace FFinder.Core.Authentication
{
    public class TokenBase
    {
     


        public static string SecretKey { get; } =
            "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        public static DateTime TokenExpirationDate { get; } = DateTime.UtcNow.AddDays(7);
        public static string Connection { get; } = "Data Source=94.73.148.5;initial catalog=u8206796_ffinder;User Id=u8206796_ffinder;Password=YSly33E0JGyv67U";

    }
}