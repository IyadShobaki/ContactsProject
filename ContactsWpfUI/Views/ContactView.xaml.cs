using ContactsUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsWpfUI.Views
{
    /// <summary>
    /// Interaction logic for ContactView.xaml
    /// </summary>
    public partial class ContactView : UserControl
    {



        public ContactModel Contact
        {
            get { return (ContactModel)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(ContactModel), typeof(ContactView), new PropertyMetadata(null));



        public ContactView()
        {
            InitializeComponent();
        }
    }
}
