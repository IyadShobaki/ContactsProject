using Caliburn.Micro;
using ContactsUI.Library.Api;
using ContactsUI.Library.Models;
using ContactsWpfUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactsWpfUI.ViewModels
{
    public class NewContactViewModel : Screen
    {

        private readonly IEventAggregator _events;
        private IContactEndPoint _contactEndPoint;

        public NewContactViewModel(IEventAggregator events,
            IContactEndPoint contactEndPoint)
        {
            _events = events;
            _contactEndPoint = contactEndPoint;
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSaveContact);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSaveContact);
            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
                NotifyOfPropertyChange(() => CanSaveContact);
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
                NotifyOfPropertyChange(() => CanSaveContact);
            }
        }

        public bool CanSaveContact
        {
            get
            {
                bool output = false;
                if (FirstName?.Length > 0 &&
                    LastName?.Length > 0 &&
                    Email?.Length > 0 &&
                    PhoneNumber?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public async Task SaveContact()
        {
            ContactModel contactModel = new ContactModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber
            };

            await _contactEndPoint.CreateNewContact(contactModel);

            ResetFields();

        }
        public void MainPage()
        {
            _events.PublishOnUIThreadAsync(new ContactsEvent());
        }
        public void ResetFields()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";

        }

    }
}
