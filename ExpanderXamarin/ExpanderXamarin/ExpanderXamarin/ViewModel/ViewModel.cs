using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ExpanderXamarin
{
    [Preserve(AllMembers = true)]
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        int counter = 11;
        #endregion

        #region Properties

        public ObservableCollection<Contact> ContactsInfo { get; set; }
        #endregion

        #region Constructor

        public ViewModel()
        {
            ContactsInfo = new ObservableCollection<Contact>();
            Assembly assembly = typeof(ExpanderXamarin.ExpandableListView).GetTypeInfo().Assembly;
            int i = 0;
            foreach (var cusName in CustomerNames)
            {
                if (counter == 13)
                    counter = 1;
                var contact = new Contact(cusName);
                contact.CallTime = CallTime[i];

                contact.PhoneImage = ImageSource.FromResource("ExpanderXamarin.Images.PhoneImage.png", assembly);
                contact.ContactImage = ImageSource.FromResource("ExpanderXamarin.Images.People_Circle" + counter + ".png", assembly);
                contact.AddContact = ImageSource.FromResource("ExpanderXamarin.Images.AddContact.png", assembly);
                contact.NewContact = ImageSource.FromResource("ExpanderXamarin.Images.NewContact.png", assembly);
                contact.SendMessage = ImageSource.FromResource("ExpanderXamarin.Images.SendMessage.png", assembly);
                contact.BlockSpan = ImageSource.FromResource("ExpanderXamarin.Images.BlockSpan.png", assembly);
                contact.CallDetails = ImageSource.FromResource("ExpanderXamarin.Images.CallDetails.png", assembly);
                i++;
                ContactsInfo.Add(contact);
                counter++;
            }
        }
        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Katherin",
            "Aliza",
            "Masona" ,
            "Lia" ,
            "Jacob  " ,
            "Jayden " ,
            "Ethani  " ,
            "Noah   " ,
            "Lucas  " ,
            "Logan  " ,
            "John  " ,
        };

        string[] CallTime = new string[]
        {
            "Tunisia, 1 days ago",
            "Colombia, 1 days ago",
            "Fiji, 1 days ago",
            "Belgium, 1 days ago",
            "Japan, 1 days ago",
            "Argentina, 2 days ago",
            "Mexico, 2 days ago",
            "Guinea, 2 days ago",
            "Australia, 2 days ago",
            "Uruguay, 2 days ago",
            "Denmark, 3 days ago",
            "Peru, 3 days ago",
            "Greece, 3 days ago",
            "Austria, 3 days ago",
            "Hungary, 3 days ago",
            "Japan, 4 days ago",
            "Malaysia, 4 days ago",
            "Bermuda, 4 days ago",
            "Egypt, 4 days ago",
            "Philippines, 4 days ago",
            "Sweden, 5 days ago",
            "Vietnam, 5 days ago",
            "Yemen, 5 days ago",
            "Nepal, 5 days ago",
            "Kenya, 5 days ago",
            "Iceland, 6 days ago",
            "Canada, 6 days ago",
            "Angola, 6 days ago",
            "Italy, 6 days ago",
            "Monaco, 6 days ago",
            "Sudan, 1 week ago",
            "Togo, 1 week ago",
            "Benin, 1 week ago"
        };

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
