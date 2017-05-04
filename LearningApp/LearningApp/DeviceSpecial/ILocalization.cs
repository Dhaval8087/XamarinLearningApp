using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.DeviceSpecial
{
    public interface ILocalization
    {
        CultureInfo GetCurrentCulture();
        void SetCulture(CultureInfo cl);
    }
}
