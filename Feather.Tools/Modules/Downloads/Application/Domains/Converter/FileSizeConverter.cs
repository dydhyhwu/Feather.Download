using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Feather.Tools.Modules.Downloads.Application.Domains.Converter
{
    public class FileSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var file_size = "";
            if (value == null) return "0B";

            var size = Int64.Parse(value.ToString());
            // > 1G
            if (size > 1073741824) file_size = $"{size / 1073741824} G";
            // > 1M
            else if (size > 1048576) file_size = $"{size / 1048576} M";
            // > 1KB
            else if (size > 1024) file_size = $"{size / 1000 } KB";
            else
            {
                file_size = $"{size} B";
            }

            return file_size;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DownloadSppedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var speed_str = "";
            if (value == null) return "0B/s";

            var speed = Int64.Parse(value.ToString());
            // > 1G
            if (speed > 1073741824) speed_str = $"{speed / 1073741824} G/s";
            // > 1M
            else if (speed > 1048576) speed_str = $"{speed / 1048576} M/s";
            // > 1KB
            else if (speed > 1024) speed_str = $"{speed / 1000 } KB/s";
            else
            {
                speed_str = $"{speed} B/s";
            }

            return speed_str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "(未知)";
            return value.ToString().Split('/').Last();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
