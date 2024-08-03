namespace Kernel.Joins
{
    public static class JoinDefinition
    {
        public static JoinDescriptor InnerJoin(this ColumnDescriptor left, ColumnDescriptor right)
        {
            return (left, JoinType.Inner, right);
        }

        public static JoinDescriptor LeftJoin(this ColumnDescriptor left, ColumnDescriptor right)
        {
            return (left, JoinType.Left, right);
        }
    }
}
