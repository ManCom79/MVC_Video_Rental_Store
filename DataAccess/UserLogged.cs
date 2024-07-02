using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace DataAccess
{
    public static class UserLogged
    {
        public static int Id { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set;}
        public static string Password { get; set;}
        public static int Age { get; set;}
        public static string CardNumber { get; set;}
        public static DateTime CreatedOn { get; set;}
        public static bool IsSubscriptionExpired { get; set;}
        public static Enums.SubscriptionTypeEnum SubscriptionType { get; set;}
    }
}
