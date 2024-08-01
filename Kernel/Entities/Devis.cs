using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("devis")]
    public class Devis : Entity<Devis.Data>
    {
        public struct Data
        {
            public int id;
            public int clientid;
            public int societeid;
            public decimal mtht;
            public decimal mttva;
            public decimal mtttc;
            public DateTime dateredaction;
        }

        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [ForeignKey("client_id")]
        public int ClientId
        {
            get => this._data.clientid;
            set => SetField(ref this._data.clientid, value);
        }

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        [Column("mt_ht")]
        public decimal MtHT
        {
            get => this._data.mtht;
            set => SetField(ref this._data.mtht, value);
        }

        [Column("mt_tva")]
        public decimal MtTVA
        {
            get => this._data.mttva;
            set => SetField(ref this._data.mttva, value);
        }

        [Column("mt_ttc")]
        public decimal MtTTC
        {
            get => this._data.mtttc;
            set => SetField(ref this._data.mtttc, value);
        }

        [Column("date_redaction")]
        public DateTime DateRedaction
        {
            get => this._data.dateredaction;
            set => SetField(ref this._data.dateredaction, value);
        }

        public Client ClientFK { get; set; }
        public Societe SocieteFK { get; set; }
    }
}
