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

namespace TimeLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PayrollModel db = new PayrollModel();
        public MainWindow()
        {
            InitializeComponent();
            LoginGrid.Visibility = Visibility.Hidden;
            LogoutGrid.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int? employeeID = Int32.TryParse(LoginTxt.Text, out var tempVal) ? tempVal : (int?)null;
            db.Login(employeeID);
            string employeeFirst = db.Employees.Find(employeeID).FirstName;
            MessageBoxResult result = MessageBox.Show("Successfully Logged " + employeeFirst + " In", "Confirmation", MessageBoxButton.OK);
            LoginTxt.Clear();
            LoginGrid.Visibility = Visibility.Hidden;
        }

        private void LoginShowButton_Click(object sender, RoutedEventArgs e)
        {
            LoginGrid.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogoutGrid.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int? employeeID = Int32.TryParse(LogoutTxt.Text, out var tempVal) ? tempVal : (int?)null;
            db.Logout(employeeID);
            string employeeFirst = db.Employees.Find(employeeID).FirstName;
            MessageBoxResult result = MessageBox.Show("Successfully Logged " + employeeFirst + " Out", "Confirmation", MessageBoxButton.OK);
            LogoutTxt.Clear();
            LogoutGrid.Visibility = Visibility.Hidden;
        }
    }
}
