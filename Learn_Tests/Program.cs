using System;
using System.Security.Cryptography.X509Certificates;
namespace Learn_Tests
{
    class Program
    {
        static void Main()
        {

            // Skapa en instans av en enkel database
            IDatabase database = new UserDatabase();
            // Skapa en instans av UserManager och skicka in databasen
            UserManager userManager = new UserManager(database);


            // Använd UserManager för att lägga till, ta bort och hämta användare
            userManager.AddUser(new User(1233, "JohnDoe"));
            userManager.AddUser(new User(2423, "Astrid"));
            userManager.AddUser(new User(2343, "Anna"));
            userManager.AddUser(new User(4222, "Johan"));
            userManager.AddUser(new User(5111, "Joel"));

            bool programRunning = true;
            while (programRunning)
            {
                Console.Clear();

                int choice = 0;
                Console.WriteLine("\nAnvändardatabas\n\n1.Lista användare\n2.Lista specifik användare efter id\n3.lägg till användare\n4.ta bort användare\n5.Avsluta ");
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out choice);

                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        foreach (var item in UserDatabase.userList)// I AM TRYING TO PRINT OBJECTS AND NOT STRINGS HERE SO I NEED ToSTRING Where the strings are made also(USER CLASS).
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("-------Tryck enter för att gå tillbaka till huvudmenyn");
                        Console.ReadKey();
                        choice = 0;
                        break;

                    case 2:
                        Console.Clear();

                        Console.WriteLine("Skriv id på användare du vill hämta");
                        int inputId = 0;
                        int userChoice = 0;
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out userChoice);

                        UserDatabase.checkExistingIdGet(userChoice);

                        Console.WriteLine("-------Tryck enter för att gå tillbaka till huvudmenyn");
                        Console.ReadKey();
                        choice = 0;

                        break;

                    case 3://LÄGGA TILL ANVÄNDARE
                        Console.Clear();

                        Console.WriteLine("Välj unikt fyrsiffrigt id på användare som ska läggas till");
                        string input3 = Console.ReadLine();
                        bool result3 = int.TryParse(input3, out inputId);

                        if (result3 == false || inputId > 9999 || inputId < 1000)
                        {
                            Console.WriteLine("Felaktig inmatning, det måste vara fyra siffror");
                        }
                        else
                        {
                            UserDatabase.checkExistingIdAdd(inputId);

                        }
                        Console.WriteLine("-------Tryck enter för att gå tillbaka till huvudmenyn");
                        Console.ReadKey();
                        choice = 0;
                        break;

                    case 4:
                        Console.Clear();
                        foreach (var item in UserDatabase.userList)// I AM TRYING TO PRINT OBJECTS AND NOT STRINGS HERE SO I NEED ToSTRING Where the strings are made also(USER CLASS).
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\nMata in id på snvändare som ska tas bort:");
                        
                        string input4=Console.ReadLine();
                        bool result4=int.TryParse(input4, out userChoice);

                        userManager.GetUser(userChoice);
                        User user = userManager.GetUser(userChoice);

                        if (userChoice > 9999 || userChoice < 1000)
                        { 
                            Console.WriteLine("Felaktig inmatning, det måste vara fyra siffror");
                        }
                        else
                        {
                            Console.WriteLine($"Tar bort användare:{user.UserName} med id {userChoice}");
                            userManager.RemoveUser(userChoice);
                            user = userManager.GetUser(userChoice);
                        }

                        Console.WriteLine("-------Tryck enter för att gå tillbaka till huvudmenyn");
                        Console.ReadKey();
                        choice = 0;
                        break;

                    case 5:
                        programRunning = false;
                        break;

                    default:

                        Console.WriteLine("Felaktig inmatning, försök igen");

                        break;
                }

            }

        }
    }

}
