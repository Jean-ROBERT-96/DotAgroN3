using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("ligne_facture")]
    public class LigneFacture : Entity<LigneFacture.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public int nligne;
            public char type;
            public float quantite;
            public string libelle;
            public int factureid;
            public int articleid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(LigneFacture), nameof(Id)); }
        public static ColumnDescriptor _NLigne { get => (typeof(LigneFacture), nameof(NLigne)); }
        public static ColumnDescriptor _Type { get => (typeof(LigneFacture), nameof(Type)); }
        public static ColumnDescriptor _Quantite { get => (typeof(LigneFacture), nameof(Quantite)); }
        public static ColumnDescriptor _Libelle { get => (typeof(LigneFacture), nameof(Libelle)); }
        public static ColumnDescriptor _FactureId { get => (typeof(LigneFacture), nameof(FactureId)); }
        public static ColumnDescriptor _ArticleId { get => (typeof(LigneFacture), nameof(ArticleId)); }
        #endregion

        #region Properties
        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [Column("nligne")]
        public int NLigne
        {
            get => this._data.nligne;
            set => SetField(ref this._data.nligne, value);
        }

        [Column("type")]
        public char Type
        {
            get => this._data.type;
            set => SetField(ref this._data.type, value);
        }

        [Column("quantite")]
        public float Quantite
        {
            get => this._data.quantite;
            set => SetField(ref this._data.quantite, value);
        }

        [Column("libelle")]
        public string Libelle
        {
            get => this._data.libelle;
            set => SetField(ref this._data.libelle, value);
        }

        [ForeignKey("facture_id")]
        public int FactureId
        {
            get => this._data.factureid;
            set => SetField(ref this._data.factureid, value);
        }

        [ForeignKey("article_id")]
        public int ArticleId
        {
            get => this._data.articleid;
            set => SetField(ref this._data.articleid, value);
        }

        public Article ArticleFK { get; set; }
        #endregion
    }
}
