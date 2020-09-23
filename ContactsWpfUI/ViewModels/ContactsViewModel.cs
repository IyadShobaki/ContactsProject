using Caliburn.Micro;
using ContactsUI.Library.Api;
using ContactsUI.Library.Models;
using ContactsWpfUI.EventModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWpfUI.ViewModels
{
    public class ContactsViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private readonly IContactEndPoint _contactEndPoint;
       

        public ContactsViewModel(IEventAggregator events, 
            IContactEndPoint contactEndPoint)
        {
            _events = events;
            _contactEndPoint = contactEndPoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadContacts();
        }

        private async Task LoadContacts()
        {
            var contactList = await _contactEndPoint.GetAllContacts();
            Contacts = new List<ContactModel>(contactList);
            OriginalList = new List<ContactModel>(contactList);
        }

        public void NewContact()
        {
            _events.PublishOnUIThreadAsync(new NewContactEvent());
        }

        private List<ContactModel> _contacts;

        public List<ContactModel> Contacts
        {
            get { return _contacts; }
            set 
            {
                _contacts = value;
                NotifyOfPropertyChange(() => Contacts);
            }
        }

        List<ContactModel> OriginalList;
        
        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;

                Contacts = new List<ContactModel>(OriginalList);

                Contacts = Contacts.Where(x => x.LastName.ToUpper()
                .Contains(value.ToUpper())).ToList();


                NotifyOfPropertyChange(() => Search);
                NotifyOfPropertyChange(() => Contacts);
            }
        }


    }
}
