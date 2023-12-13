using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
namespace idcgrupp4;

public class Booking
{
    public async Task AddCustomer()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);

        Console.Clear();
        Console.WriteLine("Write first name: ");
        string firstName = Console.ReadLine();
        while (!Regex.IsMatch(firstName, @"^[a-zA-Z]+$") || firstName.Length < 3 || firstName.Length > 25)
        {
            Console.WriteLine("Invalid input. Please use only letters. Minimum 3 letters, maximum 25");
            firstName = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Write last name: ");
        string lastName = Console.ReadLine();
        while (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$") || lastName.Length < 3 || lastName.Length > 25)
        {
            Console.WriteLine("Invalid input. Please use only letters. Minimum 3 letters, maximum 25");
            lastName = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Write email: ");
        string email = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Write phone number: ");
        string phoneNumber = Console.ReadLine();
        while (!Regex.IsMatch(phoneNumber, @"^[0-9]+$") || phoneNumber.Length < 7 || phoneNumber.Length > 15)
        {
            Console.WriteLine("Please enter the correct format.");
            phoneNumber = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Write your date of birth (YYYY-MM-DD): ");
        string dateOfBirth = Console.ReadLine();
        while (!Regex.IsMatch(dateOfBirth, @"^[0-9, -]+$") || dateOfBirth.Length < 9 || dateOfBirth.Length > 11)
        {
            Console.WriteLine("Please enter the correct format.");
            dateOfBirth = Console.ReadLine();
        }
        Console.WriteLine("Added you as a customer, welcome!");


        ////DateOnly.TryParse(Console.ReadLine(), out DateOnly dateOfBirth);


        string insertQuery = @"INSERT INTO customer(name, surname, email, phone_number, date_of_birth) VALUES ($1, $2, $3, $4, $5)";

        await using (var cmd = db.CreateCommand(insertQuery))
        {
            cmd.Parameters.AddWithValue(firstName);
            cmd.Parameters.AddWithValue(lastName);
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(phoneNumber);
            cmd.Parameters.AddWithValue(dateOfBirth);

            await cmd.ExecuteNonQueryAsync();
        }
    }



}
