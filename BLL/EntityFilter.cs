using Kernel;
using Kernel.Filters;
using System.ComponentModel;

namespace BLL
{
    public abstract class EntityFilter<T> : INotifyPropertyChanged where T : Entity
    {
        public CFilter Filters { get; set; }

        public void Clear()
        {
            this.Filters.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
