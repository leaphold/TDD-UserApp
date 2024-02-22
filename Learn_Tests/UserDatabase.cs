using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Tests
{
    public class UserDatabase : IDatabase
    {

        public static List<User> userList = new List<User>();


        public void AddUser(User user)
        {

            userList.Add(user);

        }

        public void RemoveUser(int userId)
        {
            var userToRemove = userList.FirstOrDefault(u => u.UserId==userId);
            
            if (userToRemove != null)
            {
                userList.Remove(userToRemove);
            }
        }

        public User GetUser(int userId)
        {
            return userList.FirstOrDefault(u => u.UserId == userId);

        }


        public static void checkExistingIdAdd(int inputId)
        {
            var database = new UserDatabase();
            var userManager = new UserManager(database);


            Console.WriteLine("Namn på användare som ska läggas till");
            string inputName = Console.ReadLine();


            User user = userManager.GetUser(inputId);


            var checkExisting = userList.FirstOrDefault(u => u.UserId == inputId);

            if (checkExisting == null )
            {
                userManager.AddUser(new User(inputId, inputName));
            }
            else
            {
                Console.WriteLine("Felakrig inmatning eller redan existerande Id");
            }
        }

           public static void checkExistingIdGet(int userChoice)
        {
            var database = new UserDatabase();
            var userManager = new UserManager(database);

            User user = userManager.GetUser(userChoice);

            var checkExisting = userList.FirstOrDefault(u => u.UserId == userChoice);

            if (checkExisting != null )
            {
                Console.WriteLine($"Hämtad användare: {user.UserId} - {user.UserName}");            }
            else
            {
                Console.WriteLine("Couldn't find id");
            }


        }


    }
}