using BLL.Models;
using Kernel.Entities;
using Kernel.Filters;
using System.Windows.Controls;

namespace DotAgroN3.Frames
{
    /// <summary>
    /// Logique d'interaction pour FrmClients.xaml
    /// </summary>
    public partial class FrmClients : UserControl
    {
        private static FrmClients _instance;

        public ClientModel DataContext
        {
            get => (ClientModel)base.DataContext;
            set => base.DataContext = value;
        }

        private FrmClients()
        {
            InitializeComponent();
        }

        public static FrmClients GetInstance(Client? client = null)
        {
            _instance ??= new FrmClients();
            if(client != null && !_instance.DataContext.DataContext.Equals(client))
            {
                _instance.DataContext = new ClientModel(Client._Id.Equal(client.Id));
            }

            return _instance;
        }

        public void FrameQuit()
        {
            _instance = null;
        }
    }
}
