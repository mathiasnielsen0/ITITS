using System;
using System.Text;
using HashLibrary;

namespace Password_Hasher_Salt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Hasher hasher = new Hasher();

                Console.WriteLine("Hello to encryption app x159");
                Console.WriteLine("Please enter your name: ");
                var name = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                var password = Console.ReadLine();

                hasher.HashPasswordWithSalt(password, name, out var passhash, out var salt);

                Console.WriteLine("Your password is now hashed: " + "0x" + Encoding.UTF8.GetString(passhash) + ", and salt: " + "0x" +  Encoding.UTF8.GetString(salt));

                Console.WriteLine("Please enter your name again: ");
                name = Console.ReadLine();
                Console.WriteLine("Please enter your password again: ");
                password = Console.ReadLine();
                hasher.HashPasswordWithSalt(password, name, out var newPasshash, out salt);

                Console.WriteLine("New salt generated is: " + Encoding.UTF8.GetString(passhash));

                var isCorrectPassword = hasher.IsPasswordWithSaltCorrect(passhash, salt, password);

                if (isCorrectPassword)
                    Console.WriteLine("Correct password!");
                else
                    Console.WriteLine("Incorrect password!");

                Console.WriteLine("Enter Q to exit or any other key to try again");

                if (Console.ReadLine() == "Q")
                    break;
            }
        }
    }
}