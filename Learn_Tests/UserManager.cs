using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Tests
{
    public class UserManager
    {
        private readonly IDatabase _database;

        //KONSTRUKTOR
        public UserManager(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        //INTERFACE Implementering
        public void AddUser(User user)
        {

            _database.AddUser(user);

        }
        public void RemoveUser(int userId)
        {

            _database.RemoveUser(userId);
        }

        public User GetUser(int userId)
        
        {
            return _database.GetUser(userId);
        }
    }

}