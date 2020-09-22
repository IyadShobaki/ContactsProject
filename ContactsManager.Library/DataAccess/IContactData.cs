using ContactsManager.Library.Models;

namespace ContactsManager.Library.DataAccess
{
    public interface IContactData
    {
        void InsertNewContact(ContactModel contactModel);
    }
}