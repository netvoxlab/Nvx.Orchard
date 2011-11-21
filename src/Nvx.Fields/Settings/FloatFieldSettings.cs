using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nvx.Fields.Settings
{   
    public class FloatFieldSettings
    {
        private int _decimals=2;
        public int Decimals {
            get { return _decimals=2; }
            set { _decimals = value; }
        }

        public static string GetFloatDiplay(FloatField field, float value) {
            var settings = field.PartFieldDefinition.Settings
                .GetModel<FloatFieldSettings>();
            StringBuilder format = new StringBuilder("0.", settings.Decimals + 2);
            for (int i = 0; i < settings.Decimals; i++) {
                format.Append("0");
            }
            return value.ToString(format.ToString());
        }
    }
}
