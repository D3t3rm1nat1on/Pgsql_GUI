using System.Windows;

namespace Pgsql_GUI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            this.DialogResult = !string.IsNullOrEmpty(login + password);
        }
    }
}