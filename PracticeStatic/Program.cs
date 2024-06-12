using System.Reflection.Metadata.Ecma335;

namespace PracticeStatic
{
    public class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = CreateUser();
            }

            while (true)
            {
                Console.WriteLine("Please select a command.");
                Console.WriteLine("1. Show all users");
                Console.WriteLine("2. Get information by ID");
                Console.WriteLine("0. Exit");

                string command = Console.ReadLine();

                if (command == "1")
                {
                    ShowAllUsers(users);
                }
                else if (command == "2")
                {
                    Console.WriteLine("Enter user ID:");
                    int userId;

                    if (int.TryParse(Console.ReadLine(), out userId))
                    {
                        User user = User.FindUserById(users, userId);
                        if (user != null)
                        {
                            Console.WriteLine($"Id = {user.Id}, FullName = {user.FullName}, Email = {user.Email}");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid user ID.");
                    }
                }
                else if (command == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter a valid command.");
                }
            }
        }

        public static User CreateUser()
        {
            Console.WriteLine("Enter fullname:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter email address:");
            string email = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                if (!User.PasswordChecker(password))
                {
                    Console.WriteLine("Please use a strong password.");
                    continue;
                }
                else
                    return new User(fullName, email, password);
            }
        }

        public static void ShowAllUsers(User[] users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"Id = {user.Id}, FullName = {user.FullName}, Email = {user.Email}");
            }
        }
    }
}
