using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("facture")]
    public class Facture : Entity<Facture.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public int clientid;
            public int? devisid;
            public int adressefacturationid;
            public int? adresselivraisonid;
            public int societeid;
            public decimal mtht;
            public decimal mttva;
            public decimal mtttc;
            public decimal netapayer;
            public decimal reglee;
            public DateTime datefacturation;
            public DateTime datecreation;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Facture), nameof(Id)); }
        public static ColumnDescriptor _ClientId { get => (typeof(Facture), nameof(ClientId)); }
        public static ColumnDescriptor _DevisId { get => (typeof(Facture), nameof(DevisId)); }
        public static ColumnDescriptor _AdresseFacturationId { get => (typeof(Facture), nameof(AdresseFacturationId)); }
        public static ColumnDescriptor _AdresseLivraisonId { get => (typeof(Facture), nameof(AdresseLivraisonId)); }
        public static ColumnDescriptor _SocieteId { get => (typeof(Facture), nameof(SocieteId)); }
        public static ColumnDescriptor _MtHT { get => (typeof(Facture), nameof(MtHT)); }
        public static ColumnDescriptor _MtTVA { get => (typeof(Facture), nameof(MtTVA)); }
        public static ColumnDescriptor _MtTTC { get => (typeof(Facture), nameof(MtTTC)); }
        public static ColumnDescriptor _NetAPayer { get => (typeof(Facture), nameof(NetAPayer)); }
        public static ColumnDescriptor _Reglee { get => (typeof(Facture), nameof(Reglee)); }
        public static ColumnDescriptor _DateFacturation { get => (typeof(Facture), nameof(DateFacturation)); }
        public static ColumnDescriptor _DateCreation { get => (typeof(Facture), nameof(DateCreation)); }
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

        [ForeignKey("devis_id")]
        public int? DevisId
        {
            get => this._data.devisid;
            set => SetField(ref this._data.devisid, value);
        }

        [ForeignKey("adresse_facturation_id")]
        public int AdresseFacturationId
        {
            get => this._data.adressefacturationid;
            set => SetField(ref this._data.adressefacturationid, value);
        }

        [ForeignKey("adresse_livraison_id")]
        public int? AdresseLivraisonId
        {
            get => this._data.adresselivraisonid;
            set => SetField(ref this._data.adresselivraisonid, value);
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

        [Column("net_a_payer")]
        public decimal NetAPayer
        {
            get => this._data.netapayer;
            set => SetField(ref this._data.netapayer, value);
        }

        [Column("reglee")]
        public decimal Reglee
        {
            get => this._data.reglee;
            set => SetField(ref this._data.reglee, value);
        }

        [Column("date_facturation")]
        public DateTime DateFacturation
        {
            get => this._data.datefacturation;
            set => SetField(ref this._data.datefacturation, value);
        }

        [Column("date_creation")]
        public DateTime DateCreation
        {
            get => this._data.datecreation;
            set => SetField(ref this._data.datecreation, value);
        }

        public Societe SocieteFK { get; set; }
        public Client ClientFK { get; set; }
        public Adresse AdresseFacturationFK { get; set; }
        public Adresse? AdresseLivraisonFK { get; set; }
        public Devis? DevisFK { get; set; }
        public IEnumerable<LigneFacture>? LignesFacture { get; set; }
        #endregion

        public override string ToString()
        {
            return $"F{this.Id}_{this.ClientFK.ToString()}";
        }

        public override bool Equals(object? obj)
        {
            if(obj != null && obj is Facture other)
            {
                return this.Id == other.Id &&
                       this.ClientId == other.ClientId &&
                       this.DevisId == other.DevisId &&
                       this.AdresseFacturationId == other.AdresseFacturationId &&
                       this.AdresseLivraisonId == other.AdresseLivraisonId &&
                       this.SocieteId == other.SocieteId &&
                       this.MtHT == other.MtHT &&
                       this.MtTVA == other.MtTVA &&
                       this.MtTTC == other.MtTTC &&
                       this.NetAPayer == other.NetAPayer &&
                       this.Reglee == other.Reglee &&
                       this.DateFacturation == other.DateFacturation &&
                       this.DateCreation == other.DateCreation;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(ClientId);
            hash.Add(DevisId);
            hash.Add(AdresseFacturationId);
            hash.Add(AdresseLivraisonId);
            hash.Add(SocieteId);
            hash.Add(MtHT);
            hash.Add(MtTVA);
            hash.Add(MtTTC);
            hash.Add(NetAPayer);
            hash.Add(Reglee);
            hash.Add(DateFacturation);
            hash.Add(DateCreation);

            return hash.ToHashCode();
        }
    }
}
