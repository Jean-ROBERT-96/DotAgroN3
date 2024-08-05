using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Kernel
{
    public class ColumnDescriptor
    {
        private string _propertyName;
        private string _dataName;
        private string _displayName;
        private Type _entityType;
        private Type _valueType;

        public string PropertyName => _propertyName;
        public string DataName => _dataName;
        public string DisplayName => _displayName;
        public Type EntityType => _entityType;
        public Type ValueType => _valueType;

        public ColumnDescriptor(Type entityType, string propertyName)
        {
            var propertyInfo = entityType.GetProperty(propertyName);
            _propertyName = propertyName;
            _entityType = entityType;
            _valueType = propertyInfo?.PropertyType ?? typeof(object);
            _dataName = GetColumnName(propertyInfo);
            _displayName = GetDisplayName(propertyInfo);
        }

        private string GetColumnName(PropertyInfo? propertyInfo)
        {
            var foreignKeyAttribute = propertyInfo?.GetCustomAttribute<ForeignKeyAttribute>();
            if (foreignKeyAttribute != null && !string.IsNullOrWhiteSpace(foreignKeyAttribute.Name))
                return foreignKeyAttribute.Name;

            var columnAttribute = propertyInfo?.GetCustomAttribute<ColumnAttribute>();
            if (columnAttribute != null && !string.IsNullOrWhiteSpace(columnAttribute.Name))
                return columnAttribute.Name;

            return string.Empty;
        }

        private string GetDisplayName(PropertyInfo? propertyInfo)
        {
            var displayAttribute = propertyInfo?.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null && !string.IsNullOrWhiteSpace(displayAttribute.Name))
                return displayAttribute.Name;

            return string.Empty;
        }

        public static implicit operator ColumnDescriptor((Type EntityType, string PropertyName) tuple) => new(tuple.EntityType, tuple.PropertyName);
    }
}
