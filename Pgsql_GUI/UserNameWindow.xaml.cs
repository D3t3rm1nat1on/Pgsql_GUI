using System.Windows;

namespace Pgsql_GUI
{
    public partial class UserNameWindow : Window
    {
        public UserNameWindow()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            string userName = TextBoxUserName.Text.Trim();
            this.DialogResult = !string.IsNullOrEmpty(userName);
        }
    }
}