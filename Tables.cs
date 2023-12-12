using Npgsql;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
public class Table
{
    

    public async Task CreateTable()
    {
    string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=idcgrupp4";

    await using var db = NpgsqlDataSource.Create(dbUri);
        



// Drop the tables with CASCADE
await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS room CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS booking CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS customer CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS hotel CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}


await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS customer (id SERIAL PRIMARY KEY, name VARCHAR, surname VARCHAR, email VARCHAR, phone_number VARCHAR, date_of_birth DATE)"))
{
    await cmd.ExecuteNonQueryAsync();
}


await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS booking (id SERIAL PRIMARY KEY, customer INT references customer(id), check_in DATE, check_out DATE, is_deleted BOOL)"))
{
    await cmd.ExecuteNonQueryAsync();
}


await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS room (number SERIAL PRIMARY KEY, size VARCHAR, available BOOL)"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS hotel (number SERIAL PRIMARY KEY, name VARCHAR, booking INT references booking(id), distance_To_Beach INT, distance_To_Centrum INT)"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("ALTER TABLE hotel ADD CONSTRAINT hotel_name UNIQUE (name)"))
{
    await cmd.ExecuteNonQueryAsync();
}


await using (var cmd = db.CreateCommand("ALTER TABLE room ADD COLUMN IF NOT EXISTS hotel_name VARCHAR"))
{
    await cmd.ExecuteNonQueryAsync();
}

await using (var cmd = db.CreateCommand("ALTER TABLE room ADD CONSTRAINT  fk_room_hotel FOREIGN KEY (hotel_name) REFERENCES hotel(name)"))
{
    await cmd.ExecuteNonQueryAsync();
}

}
}