using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("article")]
    public class Article : Entity<Article.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public string libelle;
            public decimal prixht;
            public float txtva;
            public decimal prixttc;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Article), nameof(Id)); }
        public static ColumnDescriptor _Libelle { get => (typeof(Article), nameof(Libelle)); }
        public static ColumnDescriptor _PrixHT { get => (typeof(Article), nameof(PrixHT)); }
        public static ColumnDescriptor _TxTVA { get => (typeof(Article), nameof(TxTVA)); }
        public static ColumnDescriptor _PrixTTC { get => (typeof(Article), nameof(PrixTTC)); }
        #endregion

        #region Properties
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
        #endregion

        public override string ToString()
        {
            return this.Libelle;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Article other)
            {
                return this.Id == other.Id &&
                       this.Libelle == other.Libelle &&
                       this.PrixHT == other.PrixHT &&
                       this.TxTVA == other.TxTVA &&
                       this.PrixTTC == other.PrixTTC;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Libelle);
            hash.Add(this.PrixHT);
            hash.Add(this.TxTVA);
            hash.Add(this.PrixTTC);

            return hash.ToHashCode();
        }
    }
}
