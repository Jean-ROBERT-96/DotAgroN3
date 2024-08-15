using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("client")]
    public class Client : Entity<Client.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public string nom;
            public string prenom;
            public int societeid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Client), nameof(Id)); }
        public static ColumnDescriptor _Nom { get => (typeof(Client), nameof(Nom)); }
        public static ColumnDescriptor _Prenom { get => (typeof(Client), nameof(Prenom)); }
        public static ColumnDescriptor _SocieteId { get => (typeof(Client), nameof(SocieteId)); }
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

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        public Societe SocieteFK { get; set; }
        #endregion

        public override string ToString()
        {
            return $"{this.Nom} {this.Prenom}";
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Client other)
            {
                return this.Id == other.Id &&
                       this.Nom == other.Nom &&
                       this.Prenom == other.Prenom &&
                       this.SocieteId == other.SocieteId;
            }

            return base.Equals(obj);
        }
    }
}
