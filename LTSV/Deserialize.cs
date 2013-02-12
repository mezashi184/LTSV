using System;
using System.Collections.Generic;
using System.Reflection;

namespace LTSV
{
    internal static class Deserialize
    {
        public static Record Line(string line)
        {
            return new Record(LineParser.Parse(line));
        }

        public static T Line<T>(string line)
        {
            Type type = typeof (T);
            T instance = Activator.CreateInstance<T>();
            IEnumerable<KeyValuePair<string, string>> keyValuePairs = LineParser.Parse(line);
            foreach (KeyValuePair<string, string> pair in keyValuePairs)
            {
                PropertyInfo propertyInfo = type.GetProperty(pair.Key);
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType == typeof (string))
                {
                    propertyInfo.SetValue(instance, pair.Value, null);
                }
                else if (propertyType == typeof (int))
                {
                    propertyInfo.SetValue(instance, int.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(double))
                {
                    propertyInfo.SetValue(instance, double.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(ushort))
                {
                    propertyInfo.SetValue(instance, ushort.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(short))
                {
                    propertyInfo.SetValue(instance, short.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(uint))
                {
                    propertyInfo.SetValue(instance, uint.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(long))
                {
                    propertyInfo.SetValue(instance, long.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(ulong))
                {
                    propertyInfo.SetValue(instance, ulong.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(float))
                {
                    propertyInfo.SetValue(instance, float.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(byte))
                {
                    propertyInfo.SetValue(instance, byte.Parse(pair.Value), null);
                }
                else if (propertyType == typeof(sbyte))
                {
                    propertyInfo.SetValue(instance, sbyte.Parse(pair.Value), null);
                }
                else
                {
                    propertyInfo.SetValue(instance, Activator.CreateInstance(propertyType, pair.Value), null);
                }
            }
            return instance;
        }
    }
}