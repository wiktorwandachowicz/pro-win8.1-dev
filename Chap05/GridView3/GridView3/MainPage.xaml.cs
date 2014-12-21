using GridView3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GridView3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IList<Person> people;
        private ObservableCollection<Group<string, Person>> groupedPeople;

        public MainPage()
        {
            this.InitializeComponent();

            people = Person.CreatePeople(25).ToList();
            FilterPeople();
        }

        private void FilterPeople()
        {
            var result = (from person in people
                          group person by person.City into g
                          orderby g.Key
                          select new Group<string, Person>
                          {
                              Key = g.Key.ToString(),
                              Items = new ObservableCollection<Person>(g.ToList())
                          }).ToList();
            groupedPeople = new ObservableCollection<Group<string, Person>>(result);
            cvs.Source = groupedPeople;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Person> people = Person.CreatePeople(1);
            Person person = people[0];
            var result = (from g in groupedPeople
                          where g.Key == person.City
                          select g);
            if (result.Count() > 0)
            {
                Group<string, Person> group = result.First();
                //group.Items.Add(person);
                group.Items.AddSorted(person);
            }
            else
            {
                Group<string, Person> group = new Group<string, Person>
                {
                    Key = person.City,
                    Items = new ObservableCollection<Person>(people.ToList())
                };
                //groupedPeople.Add(group);
                groupedPeople.AddSorted(group);
            }
            cvs.Source = groupedPeople;
        }

        private void CmdSwitch_Click(object sender, RoutedEventArgs e)
        {
            myGridView.Visibility = (myGridView.Visibility == Visibility.Collapsed) ?
                Visibility.Visible : Visibility.Collapsed;
            myListView.Visibility = (myListView.Visibility == Visibility.Collapsed) ?
                Visibility.Visible : Visibility.Collapsed;
        }
    }
}
