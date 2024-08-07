using Kernel;

namespace BLL
{
    public abstract class GenericViewModel<T> where T : Entity
    {
        public T dataContext { get; init; }
        public bool IsNewValue { get; init; }
        public string? errorMessage { get; protected set; }

        public bool Save()
        {
            if(!PreSave())
                return false;
            if(!OnSaving())
                return false;
            if(!PostSave())
                return false;

            return true;
        }

        public abstract bool IsModified(T oldValue);

        protected virtual bool PreSave() { return true; }

        protected virtual bool OnSaving() { return true; }

        protected virtual bool PostSave() { return true; }
    }
}
