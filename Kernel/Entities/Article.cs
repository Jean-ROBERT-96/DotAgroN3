using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("article")]
    public class Article : Entity<Article.Data>
    {
        public struct Data
        {
            public int id;
            public string libelle;
            public decimal prixht;
            public float txtva;
            public decimal prixttc;
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

        [Column("prix_ht")]
        public decimal PrixHT
        {
            get => this._data.prixht;
            set => SetField(ref this._data.prixht, value);
        }

        [Column("tx_tva")]
        public float TxTVA
        {
            get => this._data.txtva;
            set => SetField(ref this._data.txtva, value);
        }

        [Column("prix_ttc")]
        public decimal PrixTTC
        {
            get => this._data.prixttc;
            set => SetField(ref this._data.prixttc, value);
        }
    }
}
