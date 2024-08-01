using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("facture")]
    public class Facture : Entity<Facture.Data>
    {
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
    }
}
