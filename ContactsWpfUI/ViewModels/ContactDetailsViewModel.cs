using Caliburn.Micro;
using ContactsUI.Library.Models;
using ContactsWpfUI.EventModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ContactsWpfUI.ViewModels
{
    public class ContactDetailsViewModel : Screen
    {
        private readonly IEventAggregator _events;
        public ContactDetailsViewModel(IEventAggregator events)
        {
            _events = events;
        }

        private static ContactModel ContactModelTest;

        private ContactModel _contactTest;

        public ContactModel ContactTest
        {
            get { return _contactTest; }
            set 
            { 
                _contactTest = value;
                ContactModelTest = ContactTest;
                NotifyOfPropertyChange(() => ContactTest);

            }
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            Id = ContactModelTest.Id;
            NotifyOfPropertyChange(() => Id);

            FirstName = ContactModelTest.FirstName;
            NotifyOfPropertyChange(() => FirstName); 
            
            LastName = ContactModelTest.LastName;
            NotifyOfPropertyChange(() => LastName);  

            Email = ContactModelTest.Email;
            NotifyOfPropertyChange(() => Email); 

            PhoneNumber = ContactModelTest.PhoneNumber;
            NotifyOfPropertyChange(() => PhoneNumber);

        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);

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

            }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }


        public void UpdateContact()
        {
            string test = FirstName;
        }
        public void MainPage()
        {
            _events.PublishOnUIThreadAsync(new ContactsEvent());
        }

    }
}
