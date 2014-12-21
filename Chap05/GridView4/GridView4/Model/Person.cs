using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridView4.Model
{
    public class Person : INotifyPropertyChanged, IComparable<Person>
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged();
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", FirstName, LastName, City);
        }

        public int CompareTo(Person other)
        {
            string s1 = String.Format("{0} {1}", this.FirstName, this.LastName);
            string s2 = String.Format("{0} {1}", other.FirstName, other.LastName);
            return s1.CompareTo(s2);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        private static readonly string[] firstNames = { "Adam", "Bob", "Carl", "David", "Edgar", "Frank",
                                                          "George", "Harry", "Isaac", "Jesse", "Ken", "Larry" };
        private static readonly string[] lastNames = { "Aaronson", "Bobson", "Carlson", "Davidson", "Enstwhile", "Ferguson",
                                                         "Goodyear", "Harrison", "Isaacson", "Jackson", "Kennelworth", "Levine" };
        private static readonly string[] cities = { "Boston", "New York", "LA", "San Francisco", "Phoenix",
                                                      "San Jose", "Cincinnati", "Bellevue" };
        public static ObservableCollection<Person> CreatePeople(int count)
        {
            var people = new ObservableCollection<Person>();
            var r = new Random();
            for (int i = 0; i < count; i++)
            {
                var p = new Person()
                {
                    FirstName = firstNames[r.Next(firstNames.Length)],
                    LastName = lastNames[r.Next(lastNames.Length)],
                    City = cities[r.Next(cities.Length)]
                };
                people.AddSorted(p);
            }
            return people;
        }
    }
}
