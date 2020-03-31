using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace ThreeAPIDemo.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<ExpandoObject> GetData<T>
            (this IEnumerable<T> source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            var objectList = new List<ExpandoObject>(source.Count());
            var propertyInfoList = new List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(T).GetProperties(BindingFlags.Public |
                                                            BindingFlags.Instance);
                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldSplit = fields.Split(',');
                foreach (var field in fieldSplit)
                {
                    var propertyName = field.Trim();
                    var propertyInfo = typeof(T).GetProperty(propertyName,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                    {
                        throw  new Exception($"属性名：{propertyName} 没有找到");
                    }

                    propertyInfoList.Add(propertyInfo);
                }
            }

            foreach (T t in source)
            {
                var obj=new ExpandoObject();
                foreach (var propertyInfo in propertyInfoList)
                {
                    var value = propertyInfo.GetValue(t);
                    ((IDictionary<string, object>) obj).Add(propertyInfo.Name, value);
                }
                objectList.Add(obj);
            }
            return objectList;
        }
    }
}