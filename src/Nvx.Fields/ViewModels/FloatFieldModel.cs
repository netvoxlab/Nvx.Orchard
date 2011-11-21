using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nvx.Fields.ViewModels
{
    public class FloatFieldViewModel
    {
        public string Name { get; set; }
        public string Display { get; set; }
        public float Value { get; set; }
        public int Decimals { get; set; }
    }
}
