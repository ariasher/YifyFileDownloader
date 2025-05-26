namespace YifyCommon.Extensions
{
    public static class StringExtensions
    {
        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));

            if (Enum.TryParse<TEnum>(value, ignoreCase, out var result))
                return result;

            throw new ArgumentException($"'{value}' is not a valid value for enum '{typeof(TEnum).Name}'.");
        }
    }
}
