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
            StringBuilder result = new StringBuilder();

            bool isArray = typeof(IEnumerable).IsAssignableFrom(obj?.GetType()) ? true : false;
            if (!isArray)
            {
                result.Append("{\n");
                PropertyInfo [] properties =obj?.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(obj) != null) {
                        if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                        {
                            var value = property.PropertyType == typeof(string) ? $"\"{property.GetValue(obj)}\"" : $"{property.GetValue(obj)}";
                            result.Append($" \"{property.Name.ToLower()}\" : {value},\n");
                        }
                        else
                        {
                            result.Append($" \"{property.Name.ToLower()}\" : {JsonConverter(property.GetValue(obj))},\n");
                        }
                    }
                    else
                    {
                        var emptyValue =(typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) ? "[]" : "{}";
                        result.Append($" \"{property.Name.ToLower()}\" : {emptyValue},\n");
                    }                    
                }
                result.Remove(result.Length - 2, 1);
                result.Append("}");
            }
            else
            {

                result.Append("[");
                foreach (object? i in (IEnumerable)obj)
                {
                    if (i.GetType().IsPrimitive || i.GetType() == typeof(string))
                        //returnString = string.Concat(returnString, $"{i},", "\n");
                        result.Append($" {i},\n");

                    else
                        //returnString = string.Concat(returnString, $"{ JsonConverter(i)},", "\n");
                        result.Append($" {JsonConverter(i)},\n");
                }
                result.Remove(result.Length - 2, 1);
                result.Append("]");

            }
            return result.ToString();
        }
    }
}
