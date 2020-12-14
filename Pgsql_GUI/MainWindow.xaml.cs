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
using Microsoft.VisualBasic;
using Npgsql;
using Pgsql_GUI.Models;

namespace Pgsql_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Api _api;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RolesButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TasksButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RequestsButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClientSearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserNameWindow userNameWindow = new UserNameWindow();
            if (userNameWindow.ShowDialog() == true)
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(DataGridReport);
                DataGridReport.Columns.Clear();
                DataGridReport.Items.Clear();
                var query = $"select * from client where \"Name\" like '%{userNameWindow.TextBoxUserName.Text}%'";
                var command = new NpgsqlCommand(query, _api.Connection);
                var reader = command.ExecuteReader();
                // подготовка колонок для вывода результата запроса
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.Binding = new Binding(reader.GetName(i));
                    column.Header = reader.GetName(i);
                    column.IsReadOnly = true;
                    DataGridReport.Columns.Add(column);
                }

                // заполнение таблицы
                while (reader.Read())
                {
                    string[] values = new string [reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values[i] = reader.GetValue(i).ToString();
                    }

                    object model = new ClientModel(values);
                    DataGridReport.Items.Add(model);
                }

                reader.Close();
            }
            else
            {
                MessageBox.Show("ошибка пустого поля");
            }
        }

        private void ReportButton_OnClick(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(DataGridReport);
            DataGridReport.Columns.Clear();
            DataGridReport.Items.Clear();
            var query =
                "select S.\"ID_Staff\", S.\"Name\", \"Task\".\"Task_number\", \"Type\", \"Contract\", \"Start_date\", \"FInish_date\" from \"Task\" join exstaff e on \"Task\".\"Task_number\" = e.task_number join \"Staff\" S on e.id_staff = S.\"ID_Staff\"";
            var command = new NpgsqlCommand(query, _api.Connection);
            var reader = command.ExecuteReader();
            // подготовка колонок для вывода результата запроса
            for (int i = 0; i < reader.FieldCount; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding(reader.GetName(i));
                column.Header = reader.GetName(i);
                column.IsReadOnly = true;
                DataGridReport.Columns.Add(column);
            }

            // заполнение таблицы
            while (reader.Read())
            {
                string[] values = new string [reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values[i] = reader.GetValue(i).ToString();
                }

                object model = new ReportModel(values);
                DataGridReport.Items.Add(model);
            }

            reader.Close();
        }

        private void UserLoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginWindow loginWindow = new LoginWindow();
                if (loginWindow.ShowDialog() == true)
                {
                    if (loginWindow.DialogResult == false)
                    {
                        MessageBox.Show("ошибка пустых полей");
                        return;
                    }   
                    _api = new Api(loginWindow.TextBoxLogin.Text.Trim(), loginWindow.TextBoxPassword.Text.Trim());
                    //UserNameLabel =
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                MessageBox.Show($"Ошибка подключения к базе:\n{exception.Message}");
            }
        }
    }
}