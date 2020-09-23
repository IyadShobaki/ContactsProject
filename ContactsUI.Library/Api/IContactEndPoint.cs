using ContactsUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsUI.Library.Api
{
    public interface IContactEndPoint
    {
        Task CreateNewContact(ContactModel contactModel);
        Task<List<ContactModel>> GetAllContacts();
    }
}