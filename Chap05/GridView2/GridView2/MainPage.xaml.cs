using GridView2.Model;
using System;
using System.Collections.Generic;
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

namespace GridView2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IList<Person> people;
        private IList<Group<object, Person>> groupedPeople;

        public MainPage()
        {
            this.InitializeComponent();

            people = Person.CreatePeople(200).ToList();
            groupedPeople = (from person in people
                             group person by person.City into g
                             orderby g.Key
                             select new Group<object, Person>
                             {
                                Key = g.Key.ToString(),
                                Items = g.ToList()
                             }).ToList();
            cvs.Source = groupedPeople;
        }
    }
}
