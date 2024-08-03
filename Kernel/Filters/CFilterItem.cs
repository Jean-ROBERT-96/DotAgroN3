namespace Kernel.Filters
{
    public class CFilterItem
    {
        public object Left { get; private set; }
        public object? Right { get; private set; }
        public FilterType Filter { get; private set; }

        public CFilterItem(object left, FilterType filter, object? right)
        {
            this.Left = left;
            this.Right = right;
            this.Filter = filter;
        }

        public static implicit operator CFilterItem((object Left, FilterType Filter, object? Right) tuple) => new(tuple.Left, tuple.Filter, tuple.Right);
    }
}
