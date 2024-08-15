using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("ligne_devis")]
    public class LigneDevis : Entity<LigneDevis.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public int nligne;
            public char type;
            public float quantite;
            public string libelle;
            public int devisid;
            public int articleid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(LigneDevis), nameof(Id)); }
        public static ColumnDescriptor _NLigne { get => (typeof(LigneDevis), nameof(NLigne)); }
        public static ColumnDescriptor _Type { get => (typeof(LigneDevis), nameof(Type)); }
        public static ColumnDescriptor _Quantite { get => (typeof(LigneDevis), nameof(Quantite)); }
        public static ColumnDescriptor _Libelle { get => (typeof(LigneDevis), nameof(Libelle)); }
        public static ColumnDescriptor _DevisId { get => (typeof(LigneDevis), nameof(DevisId)); }
        public static ColumnDescriptor _ArticleId { get => (typeof(LigneDevis), nameof(ArticleId)); }
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

        [Column("devis_id")]
        public int DevisId
        {
            get => this._data.devisid;
            set => SetField(ref this._data.devisid, value);
        }

        [ForeignKey("article_id"), Column("article_id")]
        public int ArticleId
        {
            get => this._data.articleid;
            set => SetField(ref this._data.articleid, value);
        }

        public Article ArticleFK { get; set; }
        #endregion

        public override string ToString()
        {
            return this.Libelle;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is LigneDevis other)
            {
                return this.Id == other.Id &&
                       this.NLigne == other.NLigne &&
                       this.Type == other.Type &&
                       this.Quantite == other.Quantite &&
                       this.Libelle == other.Libelle &&
                       this.DevisId == other.DevisId &&
                       this.ArticleId == other.ArticleId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(NLigne);
            hash.Add(Type);
            hash.Add(Quantite);
            hash.Add(Libelle);
            hash.Add(DevisId);
            hash.Add(ArticleId);

            return hash.ToHashCode();
        }
    }
}
