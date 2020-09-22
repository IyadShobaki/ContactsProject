using Caliburn.Micro;
using ContactsWpfUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsWpfUI.ViewModels
{
    public class ShellViewModel : Conductor<object>,
        IHandle<NewContactEvent>, IHandle<ContactsEvent>
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<ContactsViewModel>());
           
        }

        public async Task HandleAsync(NewContactEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<NewContactViewModel>());
        }

        public async Task HandleAsync(ContactsEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<ContactsViewModel>());
        }
    }
}
