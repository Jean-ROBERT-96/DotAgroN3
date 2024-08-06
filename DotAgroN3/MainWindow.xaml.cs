using Kernel;
using Kernel.Entities;
using Kernel.Filters;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

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
            //this.CreateAdresse();
            var add1 = ServicesManager.DataBase.GetFirstEntity<Adresse>();
            var add2 = ServicesManager.DataBase.GetFirstEntity<Adresse>(Adresse._Id.Equal(6));
            var add3 = ServicesManager.DataBase.GetFirstEntity<Adresse>(Adresse._Id.Equal(1));
        }

        //private void CreateAdresse()
        //{
        //    var test = new Adresse();
        //    test.Libelle = "test";
        //    test.Adresse1 = "18, rue de la Testing";
        //    test.CodePostal = 75001;
        //    test.Ville = "Paris";

        //    ServicesManager.DataBase.Create(test);
        //}
    }
}