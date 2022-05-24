using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseltHome : Window, INotifyPropertyChanged
    {
        public ExpenseltHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;

            ExpenseDataSource = new List<Person>()
           {
                new Person()
            {
                Name="Mike",
                Department="Legal",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Lunch", ExpenseAmount=50},
                    new Expense() { ExpenseType="Transportation", ExpenseAmount=50}
                }
            },
                 new Person()
            {
                Name="Lisa",
                Department="Marketing",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Document printing", ExpenseAmount=50},
                    new Expense() { ExpenseType="Gift", ExpenseAmount=125}
                }
            },
                  new Person()
            {
                Name="John",
                Department="Engineering",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50},
                    new Expense() { ExpenseType="New machine", ExpenseAmount=600},
                    new Expense() { ExpenseType="Software", ExpenseAmount=500}
                }
            },
                      new Person()
            {
                Name="Mary",
                Department="Finance",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100},
                }
            },
                      new Person()
            {
                Name="Theo",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100},
                }
            },
                      new Person()
            {
                Name="James",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=200},
                }
            },
                      new Person()
            {
                Name="David",
                Department="Markenting",
                Expenses=new List<Expense>()
                {
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=50},
                }
            }
           };
            MainCaptionText = "View Expense Report :";
            PeopleChecked = new ObservableCollection<string>();
        }

        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        public ObservableCollection<string> PeopleChecked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        /* {
             add
             {
                 throw new NotImplementedException();
             }

             remove
             {
                 throw new NotImplementedException();
             }
         }*/
        private DateTime lastChecked;
        public DateTime LastChecked { get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Last Checked"));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport report = new ExpenseReport(peopleListBox.SelectedItem);
            report.Height = Height;
            report.Width = Width;
            report.ShowDialog();
        }

        private void PeopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PeopleChecked.Add(peopleListBox.SelectedItem.ToString());
            //PeopleChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value); 
            //PeopleChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).GetAttributeNode("Name").Value);
        }
    }
}
