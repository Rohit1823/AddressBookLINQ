using System;
using System.Data;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book linq problem!");
            AddressBook addressBook = new AddressBook();
            DataTable dataTable = addressBook.AddressBookDataTable();
            //addressBook.GetAllContacts(dataTable);
            //addressBook.EditContact(dataTable);
            addressBook.DeleteContact(dataTable);
            Console.ReadLine();
        }
    }
}
