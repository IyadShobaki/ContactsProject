using Caliburn.Micro;
using ContactsUI.Library.Api;
using ContactsWpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ContactsWpfUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {

            _container.Instance(_container)
            .PerRequest<IContactEndPoint, ContactEndPoint>();

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();



            // Use reflection to get all models inside ViewModels folder
            GetType().Assembly.GetTypes()
                    .Where(type => type.IsClass)
                    .Where(type => type.Name.EndsWith("ViewModel"))
                    .ToList()
                    .ForEach(viewModelType => _container.RegisterPerRequest(
                        viewModelType, viewModelType.ToString(), viewModelType));
        }
        // On startup launch ShellViewModel as base view
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            // when we pass a type and a name we will get an instance
            // for example ShellViewModel
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
