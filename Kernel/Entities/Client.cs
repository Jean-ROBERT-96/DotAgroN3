using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("client")]
    public class Client : Entity<Client.Data>
    {
        public struct Data
        {
            public int id;
            public string nom;
            public string prenom;
            public int societeid;
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
    }
}
