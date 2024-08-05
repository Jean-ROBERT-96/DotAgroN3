using Kernel;
using Kernel.Entities;
using System.Windows;

namespace DotAgroN3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CreateAdresse();
        }

        private void CreateAdresse()
        {
            var test = new Adresse();
            test.Libelle = "test";
            test.Adresse1 = "18, rue de la Testing";
            test.CodePostal = 75001;
            test.Ville = "Paris";

            ServicesManager.DataBase.Create(test);
        }
    }
}