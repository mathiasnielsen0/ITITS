using System;
using System.Text;
using HashLibrary;

namespace Encryption_App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Hasher hasher = new Hasher();

                Console.WriteLine("Hello to encryption app x158");
                Console.WriteLine("Please enter your password: ");
                var password = Console.ReadLine();

                var hash = hasher.HashPassword(password);

                Console.WriteLine("Your password is now hashed: " + "0x" + Encoding.UTF8.GetString(hash));

                Console.WriteLine("Enter your password again, and check if hashed values are the same: ");
                password = Console.ReadLine();
                var newHash = hasher.HashPassword(password);

                var isCorrectPassword = hasher.IsPasswordCorrect(hash, password);

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