using Library.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString;
        ObservableCollection<Author> listOfAuthors = new ObservableCollection<Author>();

        public MainWindow()
        {
            InitializeComponent();

            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            _connectionString = connections["LibraryConnectionString"].ConnectionString;
        }

        #region Database
        private void Add(Author author)
        {
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                string command = "INSERT INTO Author (Name,Surname,DateOfBirth,Nationality) VALUES(@name,@surname,@dateOfBirth,@nationality)";

                SqlCommand sc = new SqlCommand(command, connect);
                sc.Parameters.AddWithValue("@name", author.Name);
                sc.Parameters.AddWithValue("@surname", author.Surname);
                sc.Parameters.AddWithValue("@dateOfBirth", author.DateOfBirth);
                sc.Parameters.AddWithValue("@nationality", author.Nationality);


                sc.ExecuteNonQuery();

                connect.Close();
            }
        }

        private void Update(Author author)
        {
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                string command = "UPDATE Authors SET Name=@name, Surname=@surname, DateOfBirth=@dateOfBirth, Nationality=@nationality WHERE AuthorID=@id";

                SqlCommand sc = new SqlCommand(command, connect);

                sc.Parameters.AddWithValue("@id", author.AuthorID);
                sc.Parameters.AddWithValue("@name", author.Name);
                sc.Parameters.AddWithValue("@surname", author.Surname);
                sc.Parameters.AddWithValue("@dateOfBirth", author.DateOfBirth);
                sc.Parameters.AddWithValue("@nationality", author.Nationality);

                sc.ExecuteNonQuery();

                connect.Close();
            }
        }

        private void Delete(Author author)
        {
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                string command = "DELETE FROM Person WHERE AuthorID=@id";

                SqlCommand sc = new SqlCommand(command, connect);

                sc.Parameters.AddWithValue("@id", author.AuthorID);

                sc.ExecuteNonQuery();

                connect.Close();
            }
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                connect.Open();

                string command = "SELECT * FROM Person";

                SqlCommand sc = new SqlCommand(command, connect);

                SqlDataAdapter sa = new SqlDataAdapter(sc);
                sa.Fill(dt);

            }
        }


        #endregion

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }
    }
}
