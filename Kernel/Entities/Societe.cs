using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("societe")]
    public class Societe : Entity<Societe.Data>
    {
        public struct Data
        {
            public int id;
            public string nom;
            public string siret;
            public int adresseid;
        }

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
    }
}
