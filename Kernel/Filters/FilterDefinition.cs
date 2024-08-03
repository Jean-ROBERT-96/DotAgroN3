namespace Kernel.Filters
{
    public static class FilterDefinition
    {
        public static CFilter Equal(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.Equal, value);
        }

        public static CFilter NotEqual(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.NotEqual, value);
        }

        public static CFilter GreaterThan(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.GreaterThan, value);
        }

        public static CFilter LessThan(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.LessThan, value);
        }

        public static CFilter GreaterThanOrEqual(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.GreaterThanOrEqual, value);
        }

        public static CFilter LessThanOrEqual(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.LessThanOrEqual, value);
        }

        public static CFilter Like(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.Like, value);
        }

        public static CFilter NotLike(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.NotLike, value);
        }

        public static CFilter In(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.In, value);
        }

        public static CFilter NotIn(this ColumnDescriptor self, object value)
        {
            return (self, FilterType.NotIn, value);
        }

        public static CFilter IsNull(this ColumnDescriptor self)
        {
            return (self, FilterType.IsNull, null);
        }

        public static CFilter IsNotNull(this ColumnDescriptor self)
        {
            return (self, FilterType.IsNotNull, null);
        }
    }
}
