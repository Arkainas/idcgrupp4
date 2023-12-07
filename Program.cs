using Npgsql;

string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

await using var db = NpgsqlDataSource.Create(dbUri);

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS customer"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS customer (email VARCHAR PRIMARY KEY, name VARCHAR, surname VARCHAR, phone_number VARCHAR, date_of_birth DATE)"))
{
    await cmd.ExecuteNonQueryAsync();
}

