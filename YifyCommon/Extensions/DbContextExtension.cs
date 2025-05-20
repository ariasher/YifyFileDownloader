using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace YifyCommon.Extensions
{
    public static class DbContextExtension
    {
        private static Dictionary<IProperty, int> _maxLengthMetadataCache;

        private static Dictionary<IProperty, int> GetMaxLengthMetadata(this DbContext db)
        {
            if (_maxLengthMetadataCache == null)
            {
                _maxLengthMetadataCache = new Dictionary<IProperty, int>();

                var entities = db.Model.GetEntityTypes();
                foreach (var entityType in entities)
                {
                    foreach (var property in entityType.GetProperties())
                    {
                        var annotation = property.GetAnnotations().FirstOrDefault(a => a.Name == "MaxLength");
                        if (annotation != null)
                        {
                            var maxLength = Convert.ToInt32(annotation.Value);
                            if (maxLength > 0)
                            {
                                _maxLengthMetadataCache[property] = maxLength;
                            }
                        }
                    }
                }
            }

            return _maxLengthMetadataCache;
        }

        public static void AutoTruncateStringToMaxLength(this DbContext db)
        {
            var entries = db?.ChangeTracker?.Entries();
            if (entries == null)
            {
                return;
            }

            var maxLengthMetadata = db.GetMaxLengthMetadata();

            foreach (var entry in entries)
            {
                var propertyValues = entry.CurrentValues.Properties.Where(p => p.ClrType == typeof(string));

                foreach (var prop in propertyValues)
                {
                    if (entry.CurrentValues[prop.Name] != null)
                    {
                        var stringValue = entry.CurrentValues[prop.Name].ToString();
                        if (maxLengthMetadata.ContainsKey(prop))
                        {
                            var maxLength = maxLengthMetadata[prop];
                            stringValue = TruncateString(stringValue, maxLength);
                        }

                        entry.CurrentValues[prop.Name] = stringValue;
                    }
                }
            }
        }

        private static string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
