using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kernel
{
    public abstract class Entity<TData> : INotifyPropertyChanged where TData : struct
    {
        protected TData _data;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetField<TField>(ref TField field, TField value, [CallerMemberName] string propertyName = null)
        {
            TField oldValue = field;
            field = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
