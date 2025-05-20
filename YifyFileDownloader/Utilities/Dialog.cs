namespace YifyFileDownloader.Utilities
{
    public static class Dialog
    {
        public enum Type
        {
            Information,
            Error,
            Warning
        };

        public static void ShowMessage(string title, string message, Type type)
        {
            MessageBoxIcon icon = type switch {
                Type.Warning => MessageBoxIcon.Warning,
                Type.Error => MessageBoxIcon.Error,
                _ => MessageBoxIcon.Information
            };

            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
    }
}
