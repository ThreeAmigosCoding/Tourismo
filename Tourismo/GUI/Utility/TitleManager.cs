using System;

namespace Tourismo.GUI.Utility
{
    public static class TitleManager
    {
        private static string? _title;

        public static string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnTitleChanged();
            }
        }

        public static event Action? TitleChanged;

        public static void OnTitleChanged()
        {
            TitleChanged?.Invoke();
        }
    }
}
