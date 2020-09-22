using ContactsUI.Library.Models;
using System.Threading.Tasks;

namespace ContactsUI.Library.Api
{
    public interface IContactEndPoint
    {
        Task CreateNewContact(ContactModel contactModel);
    }
}