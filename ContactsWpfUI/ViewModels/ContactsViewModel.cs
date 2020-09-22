using Caliburn.Micro;
using ContactsWpfUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWpfUI.ViewModels
{
    public class ContactsViewModel : Screen
    {
        private readonly IEventAggregator _events;

        public ContactsViewModel(IEventAggregator events)
        {
            _events = events;
        }
        public void NewContact()
        {
            _events.PublishOnUIThreadAsync(new NewContactEvent());
        }
        
    }
}
