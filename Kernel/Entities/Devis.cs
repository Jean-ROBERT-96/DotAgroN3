using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("devis")]
    public class Devis : Entity<Devis.Data>
    {
        #region Fields
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
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Devis), nameof(Id)); }
        public static ColumnDescriptor _ClientId { get => (typeof(Devis), nameof(ClientId)); }
        public static ColumnDescriptor _SocieteId { get => (typeof(Devis), nameof(SocieteId)); }
        public static ColumnDescriptor _MtHT { get => (typeof(Devis), nameof(MtHT)); }
        public static ColumnDescriptor _MtTVA { get => (typeof(Devis), nameof(MtTVA)); }
        public static ColumnDescriptor _MtTTC { get => (typeof(Devis), nameof(MtTTC)); }
        public static ColumnDescriptor _DateRedaction { get => (typeof(Devis), nameof(DateRedaction)); }
        #endregion

        #region Properties
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
        public IEnumerable<LigneDevis>? LignesDevis { get; set; }
        #endregion

        public override string ToString()
        {
            return $"D{this.Id}_{this.ClientFK.ToString()}";
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Devis other)
            {
                return this.Id == other.Id &&
                       this.ClientId == other.ClientId &&
                       this.SocieteId == other.SocieteId &&
                       this.MtHT == other.MtHT &&
                       this.MtTVA == other.MtTVA &&
                       this.MtTTC == other.MtTTC &&
                       this.DateRedaction == other.DateRedaction;
            }

            return base.Equals(obj);
        }
    }
}
