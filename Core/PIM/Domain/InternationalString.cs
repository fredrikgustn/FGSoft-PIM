using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Core.PIM.Domain
{
    class InternationalString
    {
        public InternationalString() 
        {
            Values = new Dictionary<CultureInfo, String>();
        }

        private Dictionary<System.Globalization.CultureInfo, String> Values {get; set;}

        public String Value(CultureInfo cultureInfo)
        {
            String returnedValue = null;
            bool hasValue = Values.TryGetValue(cultureInfo, out returnedValue);
            if (!hasValue)
            {
                return null;
            }
            return returnedValue;
        }

        public void Set(CultureInfo cultureInfo, String value)
        {
            if (Values.ContainsKey(cultureInfo))
            {
                Values.Remove(cultureInfo);
            }
            Values.Add(cultureInfo, value);
        }

        public List<CultureInfo> AllCultureInfo()
        {
            List<CultureInfo> allKeys = new List<CultureInfo>();

            foreach (CultureInfo item in Values.Keys)
            {
                allKeys.Add(item);
            }

            return allKeys;
        }

    }
}
