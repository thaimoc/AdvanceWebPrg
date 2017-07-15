using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Utilities
{
    public static class TypeExtensions
    {
        public static T ChangeTypeTo<T>(this object value)
        {
            Type conversionType = typeof(T);
            return (T)value.ChangeTypeTo(conversionType);
        }

        public static T ChangeTypeTo<T>(this object value, T defaultValue)
        {
            try
            {
                Type conversionType = typeof(T);
                return (T)value.ChangeTypeTo(conversionType);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static object ChangeTypeTo(this object value, Type conversionType)
        {
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else
            {
                if (conversionType == typeof(Guid))
                    return new Guid(value.ToString());
                if((conversionType == typeof(long)) && (value.GetType() == typeof(int)))
                    throw new InvalidOperationException("Can't convert an Int64 (long) to Int32(int). If you're using SQLite - this is probably due to your PK being an INTEGER, which is 64bit. You'll need to set your key to long.");
            }
            return Convert.ChangeType(value, conversionType);
        }

        public static T CopyTo<T>(this object From, T to) where T : class
        {
            Type t = From.GetType();
            to = From.ToDictionary().FromDictionary<T>(to);
            return to;
            
        }

        public static string Format(this object value, string format)
        {
            return string.Format(format, value);
        }

        public static T FromDictionary<T>(this Dictionary<string, object> settings, T item) where T : class
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
                if (settings.ContainsKey(pi.Name) && pi.CanWrite)
                    pi.SetValue(item, settings[pi.Name], null);
            return item;
        }

        public static bool IsNullOrWhiteSpace(this object value)
        { 
            return ((value == null) || (value.ToString().Trim() == ""));
        }

        public static IDictionary<string, object> Merge(this IDictionary<string, object> source, params IDictionary<string, object>[] dictionaries)
        {
            foreach (IDictionary<string, object> dic in dictionaries)
                foreach (string key in dic.Keys)
                    source.Merge(key, dic[key]);
            return source;
        }

        public static void Merge(this IDictionary<string, object> dic, string key, object value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] = value;
        }

        public static Dictionary<string, object> ToDictionary(this object value)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            PropertyInfo[] props = value.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                try
                {
                    result.Add(pi.Name, pi.GetValue(value, null));
                }
                catch { }
            }
            return result;
        }

        public static Dictionary<string, string> ToDictionary(this NameValueCollection value, string prefix)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            int index = prefix.Length;
            foreach (string key in value.AllKeys)
                if (key.StartsWith(prefix))
                    dic.Add(key.Substring(index), value[key]);
            return dic;
        }

        public static List<string> ToParams(this NameValueCollection value, string name = "cid")
        {
            if (value[name] == null)
                return new List<string>();
            return (from id in value[name].Split(new char[] { ',' })
                    let trinmed = id.Trim()
                    where !string.IsNullOrEmpty(trinmed)
                    select trinmed).ToList<string>();
        }
    }
}
