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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            james.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Името трябва да съдържа поне 2 символа!");
            } else
            {
                string temp = "";
                foreach(var item in wpfGrid.Children)
                {
                    if (item is TextBox)
                    {
                        temp += ((TextBox)item).Text;
                        temp += '\n';
                    }
                }
            MessageBox.Show("button greets " + txtName.Text + ", " 
                + txtName1.Text + ", " + txtName2.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            block1.Text = DateTime.Now.ToString();
            MessageBox.Show("new gigantic button");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyMessage beingExtraMessage = new MyMessage();
            beingExtraMessage.Show();
            /*string message;
            message = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Guten Tag, " + message);*/
        }
    }
}
