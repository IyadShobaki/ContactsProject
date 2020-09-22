using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Library.DataAccess;
using ContactsManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactData _contactData;

        public ContactController(IContactData contactData)
        {
            _contactData = contactData;
        }
        [HttpPost]
        public void Post(ContactModel contactModel)
        {
            _contactData.InsertNewContact(contactModel);
        }
    }
}
