using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nvx.Fields.ViewModels
{
    public class DateTimeFieldViewModel
    {
        public string Name { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }

        public bool ShowDate { get; set; }
        public bool ShowTime { get; set; }
    }
}
