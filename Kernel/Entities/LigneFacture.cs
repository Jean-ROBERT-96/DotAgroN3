using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("ligne_facture")]
    public class LigneFacture : Entity<LigneFacture.Data>
    {
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

        public Facture FactureFK { get; set; }
        public Article ArticleFK { get; set; }
    }
}
