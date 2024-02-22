using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Tests
{
    public interface IDatabase
    {
        void AddUser(User user);      

        void RemoveUser(int userId);  

        User GetUser(int userId);
    }
}