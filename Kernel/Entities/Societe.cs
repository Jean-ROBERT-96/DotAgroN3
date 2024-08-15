using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("societe")]
    public class Societe : Entity<Societe.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public string nom;
            public string siret;
            public int adresseid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Societe), nameof(Id)); }
        public static ColumnDescriptor _Nom { get => (typeof(Societe), nameof(Nom)); }
        public static ColumnDescriptor _Siret { get => (typeof(Societe), nameof(Siret)); }
        public static ColumnDescriptor _AdresseId { get => (typeof(Societe), nameof(AdresseId)); }
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

        [Column("siret")]
        public string Siret
        {
            get => this._data.siret;
            set => SetField(ref this._data.siret, value);
        }

        [ForeignKey("adresse_id")]
        public int AdresseId
        {
            get => this._data.adresseid;
            set => SetField(ref this._data.adresseid, value);
        }

        public Adresse AdresseFK { get; set; }
        #endregion

        public override string ToString()
        {
            return this.Nom;
        }

        public override bool Equals(object? obj)
        {
            if(obj != null && obj is Societe other)
            {
                return this.Id == other.Id &&
                       this.Nom == other.Nom &&
                       this.Siret == other.Siret &&
                       this.AdresseId == other.AdresseId;
            }

            return false;
        }
    }
}
