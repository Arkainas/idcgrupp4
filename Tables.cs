﻿using Npgsql;
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
        


/*
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
*/

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

await using (var cmd = db.CreateCommand("CREATE TABLE IF NOT EXISTS hotel (name VARCHAR, booking INT references booking(id), number INT references room(number), distance_To_Beach INT, distance_To_Centrum INT, pool BOOL, Entertainment BOOL, Childrens_Club BOOL, Restaurant BOOL)"))
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


    public async void AddCustomer()
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