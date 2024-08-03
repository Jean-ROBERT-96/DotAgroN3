namespace Kernel.Filters
{
    public class OrCFilter : CFilter
    {
        public static explicit operator OrCFilter(CFilterItem[] items)
        {
            var f = new OrCFilter();
            f.AddRange(items);
            return f;
        }
    }
}
