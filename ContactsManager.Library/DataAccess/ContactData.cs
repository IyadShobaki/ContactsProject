using ContactsManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Library.DataAccess
{
    public class ContactData : IContactData
    {
        private readonly ISqlDataAccess _sql;

        public ContactData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public void InsertNewContact(ContactModel contactModel)
        {
            _sql.SaveData("dbo.spContact_Insert", contactModel, "test");
        }

        public List<ContactModel> GetContacts()
        {
            var output = _sql.LoadData<ContactModel, dynamic>("dbo.spContacts_GetAll",
                new { }, "test");

            return output;
        }
    }
}
