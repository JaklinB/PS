using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
            string sqlquery =
            @"SELECT StatusDescr
            FROM StudStatus";
            IDbCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = sqlquery;
            IDataReader reader = command.ExecuteReader();
            bool notEndOfResult;
            notEndOfResult = reader.Read();
            while (notEndOfResult)

            {
            string s = reader.GetString(0);
            StudStatusChoices.Add(s);
            notEndOfResult = reader.Read();
            }
            }
        }


        private void clearFields() 
        {
            foreach(var item in secGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        public void getStudentData() 
        {
            Student student = StudentData.TestStudents[1];
            forenameT.Text = student.forename;
            middlenameT.Text = student.middlename;
            surnameT.Text = student.surname;
            facultyT.Text = student.faculty.ToString();
            facultyNoT.Text = student.facultyNum;
            departmentT.Text = student.department.ToString();
            yearT.Text = student.year.ToString();
            statusT.Text = student.status;
            groupT.Text = student.group.ToString();
        }

        private void disableFields() 
        {
            foreach (var item in secGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }

                if (item is Label)
                {
                    ((Label)item).IsEnabled = false;
                }
            }
        }

        private void enableFields() 
        {
            foreach (var item in secGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }

                if (item is Label)
                {
                    ((Label)item).IsEnabled = true;
                }
            }
        }

        private void clrBtn_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        private void getBtn_Click(object sender, RoutedEventArgs e)
        {
            getStudentData();
        }

        private void dsblBtn_Click(object sender, RoutedEventArgs e)
        {
            disableFields();
        }

        private void nblBtn_Click(object sender, RoutedEventArgs e)
        {
            enableFields();
        }

        public void hideFields()
        {
            foreach(var item in innerGrid1.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Visibility = Visibility.Hidden;
                }
            }
            foreach (var item in innerGrid2.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Visibility = Visibility.Hidden;
                }
            }
        }

        private void showFields()
        {
            foreach (var item in secGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Visibility = Visibility.Visible;
                }
                if (item is Label)
                {
                    ((Label)item).Visibility = Visibility.Visible;
                }
                if (item is Button)
                {
                    ((Button)item).Visibility = Visibility.Visible;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
            hideFields();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            showFields();
            getStudentData();
        }
    }
}
