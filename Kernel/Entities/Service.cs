using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("service")]
    public class Service : Entity<Service.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public string libelle;
            public int societeid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(Service), nameof(Id)); }
        public static ColumnDescriptor _Libelle { get => (typeof(Service), nameof(Libelle)); }
        public static ColumnDescriptor _SocieteId { get => (typeof(Service), nameof(SocieteId)); }
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

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        public Societe SocieteFK { get; set; }
        #endregion
    }
}
