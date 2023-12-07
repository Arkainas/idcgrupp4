using Npgsql;

string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

await using var db = NpgsqlDataSource.Create(dbUri);

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS customer"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS customer (id SERIAL PRIMARY KEY, name VARCHAR, surname VARCHAR, email VARCHAR, phone_number VARCHAR, date_of_birth DATE)"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS hotels"))
{
    await cmd.ExecuteNonQueryAsync();
}

//Går ej att köra, lägg till när alla tables är färdiga. PGA Foreign keys går det inte att skapa detta table
/*
await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS hotels (name VARCHAR, Booking.ID FOREIGN KEY, Room.Number FOREIGN KEY, distance_To_Beach INT, distance_To_Centrum INT, pool BOOL, Entertainment BOOL, Childrens-Club BOOL, Restaurant BOOL)"))
{
    await cmd.ExecuteNonQueryAsync();
}
*/

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS booking"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS booking(id SERIAL PRIMARY KEY, customer  references customer(id), date DATE)"))
{
    await cmd.ExecuteNonQueryAsync();
}