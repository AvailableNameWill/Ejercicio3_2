using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Ejercicio3_2.Services
{
    public class imageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource image = null;
            if (value != null){
                byte[] byteImg = value as byte[];
                var stream = new MemoryStream(byteImg);
                image = ImageSource.FromStream(() => stream);
                /*string img = (string)value;
                image = ImageSource.FromFile(img);*/
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
