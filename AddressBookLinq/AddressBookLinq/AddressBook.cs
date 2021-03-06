using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLinq
{
    class AddressBook
    {
        public DataTable AddressBookDataTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("AddressBookType", typeof(string));
            table.Columns.Add("AddressBookName", typeof(string));


            table.Rows.Add("Rohit", "Machale", "South palace", "Pune", "Maharashtra", "535501", "8975596720", "rohit@gmail.com", "Family", "Book1");
            table.Rows.Add("Shivam", "Satpute", "KP", "Nagpur", "Maharashtra", "546489", "8570456737", "shivam@gmail.com", "Friends", "Book4");
            table.Rows.Add("Jyosmita", "Das", "New colony", "Surat", "Gujrat", "546362", "9878678593", "jyodas@gmail.com", "Profession", "Book2");
            table.Rows.Add("Charan", "Ketha", "WhiteField", "Banglore", "Karnataka", "125445", "7206326427", "charan@gmail.com", "Friends", "Book3");
            return table;
        }

        public void GetAllContacts(DataTable table)
        {
            foreach (DataRow dr in table.AsEnumerable())
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("LastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("Zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:- " + dr.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:- " + dr.Field<string>("Email"));
                Console.WriteLine("AddressBookType:- " + dr.Field<string>("AddressBookType"));
                Console.WriteLine("AddressBookName:- " + dr.Field<string>("AddressBookName"));
            }

        }
        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Jyosmita");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Das");
                contact.SetField("City", "Mumbai");
                contact.SetField("State", "Maharashtra");
            }

            Console.WriteLine("The Contact is updated succesfully!\n");
            GetAllContacts(contacts.CopyToDataTable());
        }

        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Charan");
            foreach (var row in contacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("The Contact is deleted succesfully!\n");
            GetAllContacts(table);
        }
        public void RetrieveContactByState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "Gujrat");
            foreach (var contact in contacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                     + " " + "Zip : " + contact.Field<string>("Zip") + " " + "Phone Number : " + contact.Field<string>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine("\n");
            }
        }
        public void GetSizeByCity(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["City"].Equals("Pune")).Count();
            Console.WriteLine(" : {0} ", contacts);
        }
        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            GetAllContacts(contacts.CopyToDataTable());
        }
        public void GetCountByType(DataTable table)
        {
            var friendsContacts = table.Rows.Cast<DataRow>()
                                         .Where(x => x["AddressBookType"].Equals("Friends")).Count();
            Console.WriteLine("'Friends' : {0} ", friendsContacts);
            var familyContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine("'Family' : {0} ", familyContact);
            var professionalContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Profession")).Count();
            Console.WriteLine("'Profession' : {0} ", professionalContact);
        }
    }
}
