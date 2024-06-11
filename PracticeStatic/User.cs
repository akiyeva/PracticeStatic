
namespace PracticeStatic
{
    public class User
    {
        private static int _id;
        private string _pass;
        public int Id { get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get => _pass;
            set
            {
                if (PasswordChecker(value))
                {
                    _pass = value;
                }
            }
        }
        public User(string fullName, string email, string pass)
        {
            Id = ++_id;

            FullName = fullName;
            Email = email;
            Password = pass;
        }
        public static bool PasswordChecker(string pass)
        {
            if (pass.Length < 8)
            {
                return false;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in pass)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                if (char.IsLower(c))
                    hasLower = true;
                if (char.IsDigit(c))
                    hasDigit = true;

                if (hasUpper && hasLower && hasDigit)
                {
                    return true;
                }
            }
            return false;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Id} {FullName} {Email}");
        }
        public static User FindUserById(User[] users, int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
