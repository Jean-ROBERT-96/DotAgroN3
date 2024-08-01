using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("ligne_devis")]
    public class LigneDevis : Entity<LigneDevis.Data>
    {
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

        [ForeignKey("devis_id")]
        public int DevisId
        {
            get => this._data.devisid;
            set => SetField(ref this._data.devisid, value);
        }

        [ForeignKey("article_id")]
        public int ArticleId
        {
            get => this._data.articleid;
            set => SetField(ref this._data.articleid, value);
        }

        public Devis DevisFK { get; set; }
        public Article ArticleFK { get; set; }
    }
}
