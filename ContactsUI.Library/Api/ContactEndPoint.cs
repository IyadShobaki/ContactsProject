using ContactsUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactsUI.Library.Api
{
    public class ContactEndPoint : IContactEndPoint
    {
        private readonly IAPIHelper _apiHelper;

        public ContactEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task CreateNewContact(ContactModel contactModel)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Contact", contactModel))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
