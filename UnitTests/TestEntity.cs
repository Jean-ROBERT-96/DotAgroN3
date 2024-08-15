using Kernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTests
{
    [Table("test_entity")]
    public class TestEntity : Entity<TestEntity.TData>
    {
        public struct TData
        {
            public int id;
            public string data;
        }

        public static ColumnDescriptor _Id { get => (typeof(TestEntity), nameof(Id)); }
        public static ColumnDescriptor _Data { get => (typeof(TestEntity), nameof(Data)); }

        [Key, Column("id")]
        public int Id
        {
            get => this._data.id;
            set => SetField(ref this._data.id, value);
        }
        [Column("data")]
        public string Data
        {
            get => this._data.data;
            set => SetField(ref this._data.data, value);
        }

        public override string ToString()
        {
            return this.Data;
        }

        public override bool Equals(object? obj)
        {
            if (obj is TestEntity entity)
                return entity.Id == this.Id && entity.Data == this.Data;

            return base.Equals(obj);
        }
    }
}
