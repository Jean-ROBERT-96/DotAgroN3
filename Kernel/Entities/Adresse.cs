using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("adresse")]
    public class Adresse : Entity<Adresse.Data>
    {
        public struct Data
        {
            public int id;
            public string libelle;
            public string adresse1;
            public string? adresse2;
            public string? adresse3;
            public string? complement;
            public int codepostal;
            public string ville;
            public byte? etage;
            public byte? porte;
            public string? batiment;
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

        [Column("adresse1")]
        public string Adresse1
        {
            get => this._data.adresse1;
            set => SetField(ref this._data.adresse1, value);
        }

        [Column("adresse2")]
        public string? Adresse2
        {
            get => this._data.adresse2;
            set => SetField(ref this._data.adresse2, value);
        }

        [Column("adresse3")]
        public string? Adresse3
        {
            get => this._data.adresse3;
            set => SetField(ref this._data.adresse3, value);
        }

        [Column("complement")]
        public string? Complement
        {
            get => this._data.complement;
            set => SetField(ref this._data.complement, value);
        }

        [Column("code_postal")]
        public int CodePostal
        {
            get => this._data.codepostal;
            set => SetField(ref this._data.codepostal, value);
        }

        [Column("ville")]
        public string Ville
        {
            get => this._data.ville;
            set => SetField(ref this._data.ville, value);
        }

        [Column("etage")]
        public byte? Etage
        {
            get => this._data.etage;
            set => SetField(ref this._data.etage, value);
        }

        [Column("porte")]
        public byte? Porte
        {
            get => this._data.porte;
            set => SetField(ref this._data.porte, value);
        }

        [Column("batiment")]
        public string? Batiment
        {
            get => this._data.batiment;
            set => SetField(ref this._data.batiment, value);
        }
    }
}
