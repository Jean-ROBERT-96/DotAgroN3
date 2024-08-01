using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("historique_client")]
    public class HistoriqueClient : Entity<HistoriqueClient.Data>
    {
        public struct Data
        {
            public int id;
            public int societeid;
            public int clientid;
            public DateTime date;
            public string description;
        }

        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        [ForeignKey("client_id")]
        public int ClientId
        {
            get => this._data.clientid;
            set => SetField(ref this._data.clientid, value);
        }

        [Column("date")]
        public DateTime Date
        {
            get => this._data.date;
            set => SetField(ref this._data.date, value);
        }

        [Column("description")]
        public string Description
        {
            get => this._data.description;
            set => SetField(ref this._data.description, value);
        }

        public Societe SocieteFK { get; set; }
        public Client ClientFK { get; set; }
    }
}
