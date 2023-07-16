using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Extensions
    {
        public static int AsID(this object item, int defaultint = -1)
        {
            if (item == null)
            {
                return defaultint;
            }
            int result = 0;
            int.TryParse(item.ToString(), out result);
            return result;
        }
        public static int AsInt(this object item, int defaultint = default(int))
        {
            if (item == null)
            {
                return defaultint;
            }
            int result = 0;
            int.TryParse(item.ToString(), out result);
            return result;
        }
        public static string AsString(this object item, string defaultstring = default(string))
        {
            if (item == null)
            {
                return defaultstring;
            }

            return item.ToString();
        }
        public static DateTime AsDateTime(this object item, DateTime defaultDateTime = default(DateTime))
        {
            if (item == null)
            {
                return defaultDateTime;
            }

            DateTime result;
            DateTime.TryParse(item.ToString(), out result);
            return result;
        }

        public static bool AsBool(this object item, bool defaultint = default(bool))
        {
            if (item == null)
            {
                return defaultint;
            }
            bool result = false;
            bool.TryParse(item.ToString(), out result);
            return result;
        }

        public static decimal AsDecimal(this object item, decimal defaultint = default(decimal))
        {
            if (item == null)
            {
                return defaultint;
            }
            decimal result = 0;
            decimal.TryParse(item.ToString(), out result);
            return result;
        }

        public static double AsDouble(this object item, double defaultint = default(double))
        {
            if (item == null)
            {
                return defaultint;
            }
            double result = 0;
            double.TryParse(item.ToString(), out result);
            return result;
        }

        public static byte[] AsArray(this object item, byte[] defaultint = default(byte[]))
        {
            if (item == null)
            {
                return defaultint;
            }
            if (item == DBNull.Value)
            {
                return defaultint;
            }

            return (byte[])(item);

        }
    }
}
