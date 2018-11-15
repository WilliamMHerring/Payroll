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

namespace PayrollProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MIS372Entities db = new MIS372Entities();
        public MainWindow()
        {
            InitializeComponent();
            SearchGrid.Visibility = Visibility.Hidden;
        }

        private void SearchShowButton_Click(object sender, RoutedEventArgs e)
        {
           if (SearchGrid.Visibility == Visibility.Visible)
            {
                SearchGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                SearchGrid.Visibility = Visibility.Visible;
            }   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int? employeeID = Int32.TryParse(IDTxt.Text, out var tempVal) ? tempVal : (int?)null;
            string firstName = FirstNameTxT.Text.NullIfWhiteSpace();
            string lastName = LastNameTxT.Text.NullIfWhiteSpace();
            List<GetEmployeePayments_Result2> employee = db.GetEmployeePayments(firstName, lastName, employeeID).ToList();
            EmployeeDetailGrid.ItemsSource = employee;
            EmployeeDetailGrid.CanUserSortColumns = true;
            foreach (var column in EmployeeDetailGrid.Columns)
            {
                column.Width = new DataGridLength(EmployeeDetailGrid.ActualWidth / EmployeeDetailGrid.Columns.Count, DataGridLengthUnitType.Pixel);
            }
        }

       
    }
}
