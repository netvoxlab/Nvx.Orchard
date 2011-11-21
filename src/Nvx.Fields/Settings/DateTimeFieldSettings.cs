using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nvx.Fields.Settings
{
    public enum DateTimeFieldDisplays
    {
        DateAndTime,
        DateOnly,
        TimeOnly
    }

    public class DateTimeFieldSettings
    {
        public DateTimeFieldDisplays Display { get; set; }
    }
}
