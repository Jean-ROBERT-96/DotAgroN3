using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("batiment")]
    public class Batiment : Entity<Batiment.Data>
    {
        public struct Data
        {
            public int id;
            public string libelle;
            public int adresseid;
            public int societeid;
        }

        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [Column("libelle")]
        public string Libelle
        {
            get => this._data.libelle;
            set => SetField(ref this._data.libelle, value);
        }

        [ForeignKey("adresse_id")]
        public int AdresseId
        {
            get => this._data.adresseid;
            set => SetField(ref this._data.adresseid, value);
        }

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        public Societe SocieteFK { get; set; }
        public Adresse AdresseFK { get; set; }
    }
}
