using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleCure.Shared
{
    public static class StaticUserStore
    {
        public static Dictionary<string, string> LoggedInUsers = new(); // token => username

        public static bool IsValidToken(string token)
        {
            return true;
            //return LoggedInUsers.ContainsKey(token);
        }

        public static string? GetUsername(string token)
        {
            return LoggedInUsers.TryGetValue(token, out var username) ? username : null;
        }
    }
}
