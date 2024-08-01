using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("employee")]
    public class Employee : Entity<Employee.Data>
    {
        public struct Data
        {
            public int id;
            public string nom;
            public string prenom;
            public int adresseid;
            public int societeid;
            public int serviceid;
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

        [ForeignKey("service_id")]
        public int ServiceId
        {
            get => this._data.serviceid;
            set => SetField(ref this._data.serviceid, value);
        }

        public Societe SocieteFK { get; set; }
        public Batiment BatimentFK { get; set; }
        public Service ServiceFK { get; set; }
    }
}
