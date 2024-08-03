using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("client_adresse")]
    public class ClientAdresse : Entity<ClientAdresse.Data>
    {
        #region Fields
        public struct Data
        {
            public int clientid;
            public int adresseid;
        }
        #endregion

        #region Descriptors
        public static ColumnDescriptor _ClientId { get => (typeof(ClientAdresse), nameof(ClientId)); }
        public static ColumnDescriptor _AdresseId { get => (typeof(ClientAdresse), nameof(AdresseId)); }
        #endregion

        #region Properties
        [Key, Column("client_id")]
        public int ClientId
        {
            get => this._data.clientid;
            set => SetField(ref this._data.clientid, value);
        }

        [Key, Column("adresse_id")]
        public int AdresseId
        {
            get => this._data.adresseid;
            set => SetField(ref this._data.adresseid, value);
        }

        public Client ClientPK { get; set; }
        public Adresse AdressePK { get; set; }
        #endregion
    }
}
