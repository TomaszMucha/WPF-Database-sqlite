using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System;
using System.Windows.Data;
using System.Data.SQLite;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal SQLiteCommand SqlCmd;
        internal SQLiteDataAdapter DB;
        internal DataSet DS = new DataSet();
        internal DataTable DT = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
        }

        internal static void ExecuteQuery(string txtQuery)
        {
            DatabaseHelper.conn.Open();
            SQLiteCommand SqlCmd = DatabaseHelper.conn.CreateCommand();
            SqlCmd.CommandText = txtQuery;
            SqlCmd.ExecuteNonQuery();
            DatabaseHelper.conn.Close();
            
        }
        
        //

        internal void BaseLoaded(object sender, RoutedEventArgs e)
        {
            DatabaseHelper.conn.Open();
            SqlCmd = DatabaseHelper.conn.CreateCommand();
            string CommandText = "SELECT * FROM People";
            DB = new SQLiteDataAdapter(CommandText, DatabaseHelper.conn);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            MainGrid.ItemsSource = new DataView(DT);
            DatabaseHelper.conn.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPerson AP = new AddPerson();
            AP.Show();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper.conn.Open();
            SqlCmd = DatabaseHelper.conn.CreateCommand();
            string CommandText = "SELECT * FROM People";
            DB = new SQLiteDataAdapter(CommandText, DatabaseHelper.conn);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            MainGrid.ItemsSource = new DataView(DT);
            DatabaseHelper.conn.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataRowView)MainGrid.SelectedItem!=null)
            {
                DataRowView drv = (DataRowView)MainGrid.SelectedItem;

                UpdatePerson UP = new UpdatePerson();
                UP.NameTextBoxUpdate.Text = drv[1].ToString();
                UP.SurenameTextBoxUpdate.Text = drv[2].ToString();
                UP.PhoneTextBoxUpdate.Text = drv[3].ToString();
                UP.ShowDialog();

                ExecuteQuery("UPDATE people SET Name='"+ UP.NameTextBoxUpdate.Text +
                            "', Surename='" + UP.SurenameTextBoxUpdate.Text + 
                            "', Phone='" + UP.PhoneTextBoxUpdate.Text + "' WHERE ID=" + drv[0]);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataRowView)MainGrid.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)MainGrid.SelectedItem;

                ExecuteQuery("DELETE FROM people WHERE ID=" + drv[0]);
            }
        }
    }
}
