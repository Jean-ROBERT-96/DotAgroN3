using Kernel.RightManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("utilisateur")]
    public class Utilisateur : Entity<Utilisateur.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public string nom;
            public string prenom;
            public string email;
            public string password;
            public ushort clientdroit;
            public ushort facturedroit;
            public ushort devisdroit;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Utilisateur), nameof(Id)); }
        public static ColumnDescriptor _Nom { get => (typeof(Utilisateur), nameof(Nom)); }
        public static ColumnDescriptor _Prenom { get => (typeof(Utilisateur), nameof(Prenom)); }
        public static ColumnDescriptor _Email { get => (typeof(Utilisateur), nameof(Email)); }
        public static ColumnDescriptor _Password { get => (typeof(Utilisateur), nameof(Password)); }
        public static ColumnDescriptor _ClientDroit { get => (typeof(Utilisateur), nameof(ClientDroit)); }
        public static ColumnDescriptor _FactureDroit { get => (typeof(Utilisateur), nameof(FactureDroit)); }
        public static ColumnDescriptor _DevisDroit { get => (typeof(Utilisateur), nameof(DevisDroit)); }
        #endregion

        #region Properties
        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [Column("nom")]
        public string Nom
        {
            get => this._data.nom;
            set => SetField(ref this._data.nom, value);
        }

        [Column("prenom")]
        public string Prenom
        {
            get => this._data.prenom;
            set => SetField(ref this._data.prenom, value);
        }

        [Column("email")]
        public string Email
        {
            get => this._data.email;
            set => SetField(ref this._data.email, value);
        }

        [Column("password")]
        public string Password
        {
            get => this._data.password;
            set => SetField(ref this._data.password, value);
        }

        [Column("client_droit")]
        public ushort ClientDroit
        {
            get => this._data.clientdroit;
            set => SetField(ref this._data.clientdroit, value);
        }

        [Column("facture_droit")]
        public ushort FactureDroit
        {
            get => this._data.facturedroit;
            set => SetField(ref this._data.facturedroit, value);
        }

        [Column("devis_droit")]
        public ushort DevisDroit
        {
            get => this._data.devisdroit;
            set => SetField(ref this._data.devisdroit, value);
        }
        #endregion

        public override string ToString()
        {
            return $"{this.Nom} {this.Prenom}";
        }
        public override bool Equals(object? obj)
        {
            if(obj != null && obj is Utilisateur other)
            {
                return this.Id == other.Id &&
                       this.Nom == other.Nom &&
                       this.Prenom == other.Prenom &&
                       this.Email == other.Email &&
                       this.ClientDroit == other.ClientDroit &&
                       this.FactureDroit == other.FactureDroit &&
                       this.DevisDroit == other.DevisDroit;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Nom);
            hash.Add(this.Prenom);
            hash.Add(this.Email);
            hash.Add(this.ClientDroit);
            hash.Add(this.FactureDroit);
            hash.Add(this.DevisDroit);

            return hash.ToHashCode();
        }

        public static Utilisateur ConnectedUser { get; set; }

        public bool HasClientRight(ClientRight right)
        {
            return HasRight(this.ClientDroit, (ushort)right);
        }

        public bool HasFactureRight(FactureRight right)
        {
            return HasRight(this.FactureDroit, (ushort)right);
        }

        public bool HasDevisRight(DevisRight right)
        {
            return HasRight(this.DevisDroit, (ushort)right);
        }

        private static bool HasRight(ushort userRight, ushort right)
        {
            return (userRight & right) == right;
        }
    }
}
