namespace Kernel.Orders
{
    public enum SortDirectionType
    {
        Ascending,
        Descending
    }

    public class SortDirection
    {
        public ColumnDescriptor Column { get; private set; }
        public SortDirectionType Direction { get; private set; }

        public SortDirection(ColumnDescriptor column, SortDirectionType direction = SortDirectionType.Ascending)
        {
            this.Column = column;
            this.Direction = direction;
        }

        public static implicit operator SortDirection((ColumnDescriptor Column, SortDirectionType Direction) tuple) => new(tuple.Column, tuple.Direction);
    }
}
