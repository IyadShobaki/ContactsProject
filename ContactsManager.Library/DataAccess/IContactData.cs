using ContactsManager.Library.Models;
using System.Collections.Generic;

namespace ContactsManager.Library.DataAccess
{
    public interface IContactData
    {
        void DeleteContact(int id);
        List<ContactModel> GetContacts();
        void InsertNewContact(ContactModel contactModel);
        void UpdateContact(ContactModel contactModel);
    }
}