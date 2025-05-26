namespace YifyCommon.Models.Utilities
{
    public class SerilogSettings
    {
        public string SerilogMinimumLevel { get; set; }
        public string SerilogUsingFile { get; set; }
        public string SerilogFilePath { get; set; }
        public string SerilogFileShared { get; set; }
        public string SerilogRollOnFileSizeLimit { get; set; }
        public string SerilogRollingInterval { get; set; }
        public string SerilogFileSizeLimitBytes { get; set; }

        public bool SerilogFileSharedBoolean
            => Convert.ToBoolean(SerilogFileShared);

        public long SerilogFileSizeLimitBytesLong
            => Convert.ToInt64(SerilogFileSizeLimitBytes);

        public bool SerilogRollOnFileSizeLimitBoolean
            => Convert.ToBoolean(SerilogRollOnFileSizeLimit);
    }
}
