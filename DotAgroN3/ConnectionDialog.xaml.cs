using Kernel;
using Kernel.Entities;
using Kernel.Filters;
using System.Windows;

namespace DotAgroN3
{
    /// <summary>
    /// Logique d'interaction pour ConnectionDialog.xaml
    /// </summary>
    public partial class ConnectionDialog : Window
    {
        public ConnectionDialog()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = HashManager.HashValue(txtPassword.Password);

            var filter = new AndCFilter 
            {
                Utilisateur._Email.Equal(username),
                Utilisateur._Password.Equal(password)
            };
            var user = ServicesManager.DataBase.GetFirstEntity<Utilisateur>(filter);
            if (user != null)
            {
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
