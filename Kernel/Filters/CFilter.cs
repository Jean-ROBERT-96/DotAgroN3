namespace Kernel.Filters
{
    public enum FilterType
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Like,
        NotLike,
        In,
        NotIn,
        IsNull,
        IsNotNull
    }

    public abstract class CFilter : List<CFilterItem>
    {
        public static implicit operator CFilter((object Left, FilterType Filter, object? Right) tuple) => new AndCFilter { tuple };
    }
}
