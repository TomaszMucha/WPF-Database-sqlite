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
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Logika interakcji dla klasy AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string txtQuery = "insert into people (Name, Surename, Phone) values ('" + NameTextBox.Text + "','" + SurenameTextBox.Text + "','" + PhoneTextBox.Text+"')";
            MainWindow.ExecuteQuery(txtQuery);
            this.Close();
        }
    }
}
