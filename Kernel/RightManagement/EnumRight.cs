namespace Kernel.RightManagement
{
    [Flags]
    public enum ClientRight : UInt16
    {
        None = 0,
        Read = 1 << 0,
        Create = 1 << 1,
        Update = 1 << 2,
        Delete = 1 << 3,
        All = Read | Create | Update | Delete
    }

    [Flags]
    public enum FactureRight : UInt16
    {
        None = 0,
        Read = 1 << 0,
        Create = 1 << 1,
        Update = 1 << 2,
        Delete = 1 << 3,
        All = Read | Create | Update | Delete
    }

    [Flags]
    public enum DevisRight : UInt16
    {
        None = 0,
        Read = 1 << 0,
        Create = 1 << 1,
        Update = 1 << 2,
        Delete = 1 << 3,
        All = Read | Create | Update | Delete
    }
}
