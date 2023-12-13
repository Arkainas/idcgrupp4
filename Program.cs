using idcgrupp4;
using Npgsql;
using System.Threading.Channels;

bool menu = true;

        
Table create = new Table();
create.CreateTable();


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
            Booking booking = new Booking();
            booking.AddCustomer();

            break;
        case "2":
            Console.WriteLine("Remove booking");

            Console.ReadKey();
            break;
        case "3":
            Console.WriteLine("Alter booking");
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Bye :)");
            menu = false;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

}

