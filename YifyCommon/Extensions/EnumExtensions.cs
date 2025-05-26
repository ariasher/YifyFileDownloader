namespace YifyCommon.Extensions
{
    /// <summary>
    /// Extension class for Enum.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Determines if Enum contains some value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="enumeration">Current enum reference</param>
        /// <param name="enums">Array of enums to check value in</param>
        /// <returns>Returns whether an enum is present or not</returns>
        public static bool IsAny<T>(this T enumeration, params T[] enums) where T : Enum
        {
            return enums.Contains(enumeration);
        }

        /// <summary>
        /// Determines if Enum is some value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="enumeration">Current enum reference</param>
        /// <param name="enum">Value of enum to compare</param>
        /// <returns>Returns whether an enum is equal or not</returns>
        public static bool Is<T>(this T enumeration, T @enum) where T : Enum
        {
            return @enum.Equals(enumeration);
        }

        /// <summary>
        /// Retieves name of the Enum.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="enumeration">Current enum reference</param>
        /// <returns>Returns name of the enum in text</returns>
        public static string Name<T>(this T enumeration) where T : Enum
        {
            return Enum.GetName(typeof(T), enumeration) ?? throw new InvalidCastException("The provided enum value is invalid.");
        }
    }
}
