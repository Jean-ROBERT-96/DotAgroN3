using Kernel.Interfaces;

namespace Kernel.Joins
{
    public enum JoinType
    {
        Inner,
        Left
    }

    public class JoinDescriptor
    {
        public ColumnDescriptor Left { get; private set; }
        public ColumnDescriptor Right { get; private set; }
        public JoinType Type { get; private set; }

        public JoinDescriptor(ColumnDescriptor left, JoinType type, ColumnDescriptor right)
        {
            this.Left = left;
            this.Right = right;
            this.Type = type;
        }

        public static implicit operator JoinDescriptor((ColumnDescriptor Left, JoinType Type, ColumnDescriptor Right) tuple) => new(tuple.Left, tuple.Type, tuple.Right);
    }
}
