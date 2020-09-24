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
        private readonly ContactDetailsViewModel _contactDetailsViewModel;

        public ContactsViewModel(IEventAggregator events, 
            IContactEndPoint contactEndPoint,
            ContactDetailsViewModel contactDetailsViewModel)
        {
            _events = events;
            _contactEndPoint = contactEndPoint;
            _contactDetailsViewModel = contactDetailsViewModel;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadContacts();
        }

        private async Task LoadContacts()
        {
            var contactList = (await _contactEndPoint.GetAllContacts()).OrderBy(x=>
            x.LastName);
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

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                _selectedContact = value;
                NotifyOfPropertyChange(() => SelectedContact);
                NotifyOfPropertyChange(() => CanEditContact);
            }
        }

        public bool CanEditContact
        {
            get
            {
                if (SelectedContact != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void EditContact()
        {
            _contactDetailsViewModel.ContactTest = SelectedContact;
            _events.PublishOnUIThreadAsync(new UpdateRecordEvent());
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

        public void ByFirstName()
        {
            var filterByFirstName = from c in Contacts
                                    //where c.FirstName.ToLower().Contains(Search.ToLower())
                                    orderby c.FirstName
                                    select c;
            Contacts = filterByFirstName.ToList();
            NotifyOfPropertyChange(() => Contacts);

        }
    }
}
