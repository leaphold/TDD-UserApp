using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Tests
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public User(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"ID:{UserId} - Användarnamn:{UserName}";
        }

    }
}