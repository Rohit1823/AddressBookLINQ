using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLinq
{
    class AddressBook
    {
        DataTable table = new DataTable("AddressBook");
        public AddressBook()
        {
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

        }
    }
}
