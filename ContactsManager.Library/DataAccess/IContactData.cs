using ContactsManager.Library.Models;
using System.Collections.Generic;

namespace ContactsManager.Library.DataAccess
{
    public interface IContactData
    {
        List<ContactModel> GetContacts();
        void InsertNewContact(ContactModel contactModel);
    }
}