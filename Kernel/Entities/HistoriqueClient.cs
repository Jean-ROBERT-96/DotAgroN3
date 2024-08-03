using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("historique_client")]
    public class HistoriqueClient : Entity<HistoriqueClient.Data>
    {
        #region Fields
        public struct Data
        {
            public int id;
            public int societeid;
            public int clientid;
            public DateTime date;
            public string description;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _Id { get => (typeof(HistoriqueClient), nameof(Id)); }
        public static ColumnDescriptor _SocieteId { get => (typeof(HistoriqueClient), nameof(SocieteId)); }
        public static ColumnDescriptor _ClientId { get => (typeof(HistoriqueClient), nameof(ClientId)); }
        public static ColumnDescriptor _Date { get => (typeof(HistoriqueClient), nameof(Date)); }
        public static ColumnDescriptor _Description { get => (typeof(HistoriqueClient), nameof(Description)); }
        #endregion

        #region Properties
        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }

        [ForeignKey("societe_id")]
        public int SocieteId
        {
            get => this._data.societeid;
            set => SetField(ref this._data.societeid, value);
        }

        [ForeignKey("client_id")]
        public int ClientId
        {
            get => this._data.clientid;
            set => SetField(ref this._data.clientid, value);
        }

        [Column("date")]
        public DateTime Date
        {
            get => this._data.date;
            set => SetField(ref this._data.date, value);
        }

        [Column("description")]
        public string Description
        {
            get => this._data.description;
            set => SetField(ref this._data.description, value);
        }

        public Societe SocieteFK { get; set; }
        public Client ClientFK { get; set; }
        #endregion
    }
}
