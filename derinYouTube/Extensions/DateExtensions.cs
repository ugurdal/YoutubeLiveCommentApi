using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.Extensions
{
    public static class DateExtensions
    {
        public static string ToTarih(this DateTime tarih)
        {
            return tarih.ToString("dd.MM.yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
        }
        public static string ToTarih(this DateTime? tarih)
        {
            return tarih == null 
                ? ""
                : tarih.Value.ToString("dd.MM.yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
