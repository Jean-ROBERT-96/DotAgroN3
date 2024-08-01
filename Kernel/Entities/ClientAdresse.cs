using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Entities
{
    [Table("client_adresse")]
    public class ClientAdresse : Entity<ClientAdresse.Data>
    {
        public struct Data
        {
            public int clientid;
            public int adresseid;
        }

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

        public Client ClientFK { get; set; }
        public Adresse AdresseFK { get; set; }
    }
}
