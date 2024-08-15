using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("adresse")]
    public class Adresse : Entity<Adresse.Data>
    {
        #region Fields
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
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Adresse), nameof(Id)); }
        public static ColumnDescriptor _Libelle { get => (typeof(Adresse), nameof(Libelle)); }
        public static ColumnDescriptor _Adresse1 { get => (typeof(Adresse), nameof(Adresse1)); }
        public static ColumnDescriptor _Adresse2 { get => (typeof(Adresse), nameof(Adresse2)); }
        public static ColumnDescriptor _Adresse3 { get => (typeof(Adresse), nameof(Adresse3)); }
        public static ColumnDescriptor _Complement { get => (typeof(Adresse), nameof(Complement)); }
        public static ColumnDescriptor _CodePostal { get => (typeof(Adresse), nameof(CodePostal)); }
        public static ColumnDescriptor _Ville { get => (typeof(Adresse), nameof(Ville)); }
        public static ColumnDescriptor _Etage { get => (typeof(Adresse), nameof(Etage)); }
        public static ColumnDescriptor _Porte { get => (typeof(Adresse), nameof(Porte)); }
        public static ColumnDescriptor _Batiment { get => (typeof(Adresse), nameof(Batiment)); }
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
        #endregion

        public override string ToString()
        {
            return this.Libelle;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Adresse other)
            {
                return this.Id == other.Id &&
                       this.Libelle == other.Libelle &&
                       this.Adresse1 == other.Adresse1 &&
                       this.Adresse2 == other.Adresse2 &&
                       this.Adresse3 == other.Adresse3 &&
                       this.Complement == other.Complement &&
                       this.CodePostal == other.CodePostal &&
                       this.Ville == other.Ville &&
                       this.Etage == other.Etage &&
                       this.Porte == other.Porte &&
                       this.Batiment == other.Batiment;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Libelle);
            hash.Add(Adresse1);
            hash.Add(Adresse2);
            hash.Add(Adresse3);
            hash.Add(Complement);
            hash.Add(CodePostal);
            hash.Add(Ville);
            hash.Add(Etage);
            hash.Add(Porte);
            hash.Add(Batiment);

            return hash.ToHashCode();
        }
    }
}
