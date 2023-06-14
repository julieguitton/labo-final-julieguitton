using ProjetMacdo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ageTmp = (string)value;

            if (ageTmp=="Sur Place")
            {
                return "images/surplace.png";
            }
            if (ageTmp == "Carte Bancaire")
            {
                return "images/cb.png";
            }
            if (ageTmp == "Especes")
                return "images/cash.png";
            else
                return "images/aEmporter.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
