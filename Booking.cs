using Npgsql;
namespace idcgrupp4;

public class Booking
{
    public async Task AddCustomer()
    {
        string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

        await using var db = NpgsqlDataSource.Create(dbUri);

        Console.WriteLine("Write first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Write last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Write email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Write phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Write date of birth (YYYY-MM-DD): ");
        DateOnly.TryParse(Console.ReadLine(), out DateOnly dateOfBirth);



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
