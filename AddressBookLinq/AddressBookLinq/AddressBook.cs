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

            table.Rows.Add("Rohit", "Machale", "South palace", "Pune", "Maharashtra", "535501", "8975596720", "rohit@gmail.com");
            table.Rows.Add("Shivam", "Satpute", "KP", "Nagpur", "Maharashtra", "546489", "8570456737", "shivam@gmail.com");
            table.Rows.Add("Jyosmita", "Das", "New colony", "Surat", "Gujrat", "546362", "9878678593", "jyodas@gmail.com");
            table.Rows.Add("Charan", "Ketha", "WhiteField", "Banglore", "Karnataka", "125445", "7206326427", "charan@gmail.com");
            return table;
        }

        public void GetAllContacts(DataTable table)
        {
            foreach (DataRow dr in table.AsEnumerable())
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
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
    }
}
