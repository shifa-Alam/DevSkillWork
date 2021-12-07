using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_objToJson_
{
    public class Converter
    {
        public static string JsonConverter<T>(T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool isArray = typeof(IEnumerable).IsAssignableFrom(obj?.GetType()) ? true : false;
            if (!isArray)
            {
                stringBuilder.Append("{\n");
                PropertyInfo [] properties =obj?.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(obj) != null) {
                        if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                        {
                            var value = property.PropertyType == typeof(string) ? $"\"{property.GetValue(obj)}\"" : $"{property.GetValue(obj)}";
                            stringBuilder.Append($" \"{property.Name.ToLower()}\" : {value},\n");
                        }
                        else
                        {
                            stringBuilder.Append($" \"{property.Name.ToLower()}\" : {JsonConverter(property.GetValue(obj))},\n");
                        }
                    }
                    else
                    {
                        var emptyValue =(typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) ? "[]" : "{}";
                        stringBuilder.Append($" \"{property.Name.ToLower()}\" : {emptyValue},\n");
                    }                    
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 1);
                stringBuilder.Append("}");
            }
            else
            {

                stringBuilder.Append("[");
                foreach (object? i in (IEnumerable)obj)
                {
                    if (i.GetType().IsPrimitive || i.GetType() == typeof(string))
                        //returnString = string.Concat(returnString, $"{i},", "\n");
                        stringBuilder.Append($" {i},\n");

                    else
                        //returnString = string.Concat(returnString, $"{ JsonConverter(i)},", "\n");
                        stringBuilder.Append($" {JsonConverter(i)},\n");
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 1);
                stringBuilder.Append("]");

            }
            return stringBuilder.ToString();
        }
    }
}
