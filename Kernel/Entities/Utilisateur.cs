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
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Utilisateur), nameof(Id)); }
        public static ColumnDescriptor _Nom { get => (typeof(Utilisateur), nameof(Nom)); }
        public static ColumnDescriptor _Prenom { get => (typeof(Utilisateur), nameof(Prenom)); }
        public static ColumnDescriptor _Email { get => (typeof(Utilisateur), nameof(Email)); }
        public static ColumnDescriptor _Password { get => (typeof(Utilisateur), nameof(Password)); }
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
                       this.Email == other.Email;
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

            return hash.ToHashCode();
        }
    }
}
