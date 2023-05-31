using ContactDALLib.Model;
using ContactDALLib.Repository;
using System;
using System.Collections.Generic;

namespace ContactConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=ContactDB;Integrated Security=True";
            ContactRepository contactRepository = new ContactRepository(connectionString);

            while (true)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContactToDB(contactRepository);
                        break;
                    case "2":
                        DisplayDB(contactRepository);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
        static void AddContactToDB(ContactRepository contactRepository)
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            Contact contact = new Contact
            {
                Id = id,
                Name = name,
                MobileNumber = mobileNumber
            };

            contactRepository.AddContact(contact);
            Console.WriteLine("Contact added successfully.");
        }

        static void DisplayDB(ContactRepository contactRepository)
        {
            List<Contact> contacts = contactRepository.GetContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts currently present!");
            }
            else
            {
                Console.WriteLine($"  Id    Name    Mobile Number");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"   {contact.Id}    {contact.Name}    {contact.MobileNumber}");
                }
            }
        }
    }
}
