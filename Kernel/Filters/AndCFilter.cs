namespace Kernel.Filters
{
    public class AndCFilter : CFilter
    {
        public static explicit operator AndCFilter(CFilterItem[] items)
        {
            var f = new AndCFilter();
            f.AddRange(items);
            return f;
        }
    }
}
