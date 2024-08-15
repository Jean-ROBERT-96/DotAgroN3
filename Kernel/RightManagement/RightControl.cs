using Kernel.Entities;

namespace Kernel.RightManagement
{
    public static class RightControl
    {
        // Méthodes pour écrire les droits
        public static void SetClientRight(Utilisateur utilisateur, ClientRight rights)
        {
            utilisateur.ClientDroit = (ushort)rights;
        }

        public static void SetFactureRight(Utilisateur utilisateur, FactureRight rights)
        {
            utilisateur.FactureDroit = (ushort)rights;
        }

        public static void SetDevisRight(Utilisateur utilisateur, DevisRight rights)
        {
            utilisateur.DevisDroit = (ushort)rights;
        }
    }
}
