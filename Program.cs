/*
using Npgsql;
using System.Threading.Channels;

bool menu = true;

Table _table = new Table();
_table.CreateTable();


while (menu)
{
    Console.WriteLine("==== Menu ====");
    Console.WriteLine("1. Add booking");
    Console.WriteLine("2. Remove booking");
    Console.WriteLine("3. Alter booking");
    Console.WriteLine("4. Exit");
    Console.WriteLine("=============");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            _table.AddCustomer();

            break;
        case "2":
            Console.WriteLine("Remove booking");

            Console.ReadKey();
            break;
        case "3":
            Console.WriteLine("Alter booking");
            break;
        case "4":
            Console.WriteLine("Bye :)");
            menu = false;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

}

*/

using Npgsql;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        bool menu = true;
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        using var db = new NpgsqlConnection(dbUri);
        await db.OpenAsync();

        while (menu)
        {
            Console.WriteLine("==== Menu ====");
            Console.WriteLine("1. Add customer");
            Console.WriteLine("2. Remove booking");
            Console.WriteLine("3. Alter booking");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=============");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddCustomer(db);
                    break;
                case "2":
                    Console.WriteLine("Remove booking");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Alter booking");
                    break;
                case "4":
                    Console.WriteLine("Bye :)");
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static async Task AddCustomer(NpgsqlConnection dbConnection)
    {
        Console.WriteLine("Write first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Write last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Write email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Write phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Write date of birth (YYYY-MM-DD): ");
        string dob = Console.ReadLine();

        if (!DateTime.TryParse(dob, out DateTime dateOfBirth))
        {
            Console.WriteLine("Invalid date format. Please use YYYY-MM-DD");
        }

        string insertQuery = "INSERT INTO customer(name, surname, email, phone_number, date_of_birth) VALUES (@firstName, @lastName, @email, @phoneNumber, @dateOfBirth)";

        await using (var cmd = new NpgsqlCommand(insertQuery, dbConnection))
        {
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);

            await cmd.ExecuteNonQueryAsync();
            Console.WriteLine("Customer added successfully!");
        }
    }
}
