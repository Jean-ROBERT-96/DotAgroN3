namespace Kernel.Orders
{
    public static class SortDefinition
    {
        public static SortDirection Ascending(this ColumnDescriptor column) => (column, SortDirectionType.Ascending);
        public static SortDirection Descending(this ColumnDescriptor column) => (column, SortDirectionType.Descending);
    }
}
