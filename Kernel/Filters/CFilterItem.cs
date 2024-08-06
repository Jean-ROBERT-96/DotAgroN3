namespace Kernel.Filters
{
    public class CFilterItem
    {
        public class CFilterItemContainer : CFilterItem
        {
            public CFilter Filter { get; set; }
        }

        public ColumnDescriptor Left { get; private set; }
        public object? Right { get; private set; }
        public FilterType Filter { get; private set; }

        public static implicit operator CFilterItem((ColumnDescriptor Left, FilterType Filter, object? Right) tuple) => new CFilterItem{ Left = tuple.Left, Filter = tuple.Filter, Right = tuple.Right };
        public static implicit operator CFilterItem(OrCFilter filter)
        {
            var f = new CFilterItemContainer();
            f.Filter = filter;
            return f;
        }

        public static implicit operator CFilterItem(AndCFilter filter)
        {
            var f = new CFilterItemContainer();
            f.Filter = filter;
            return f;
        }

        public static implicit operator CFilterItem(CFilter filter)
        {
            var f = new CFilterItemContainer();
            f.Filter = filter;
            return f;
        }
    }
}
