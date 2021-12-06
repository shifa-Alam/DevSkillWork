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
        private static string returnString = "";
        private static StringBuilder stringBuilder = new StringBuilder();
        public static string JsonFormatter<T>(T obj)
        {


            //var x = string.Empty;

            //if (!obj.GetType().IsPrimitive && obj.GetType() != typeof(string))
            //{

            //    var isArray = (typeof(IEnumerable).IsAssignableFrom(obj.GetType())) ? true : false;

            //    PropertyInfo[] properties = obj.GetType().GetProperties();

            //    if (!isArray)
            //    {
            //        returnString = string.Concat(returnString, "{ \n");
            //        foreach (PropertyInfo property in properties)
            //        {
            //            var value = property.GetValue(obj);
            //            if (value == null || value == string.Empty)
            //            {
            //                x = (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) ? ($"{ property.Name} :" + "[]") : ($"{ property.Name} :" + "{}");

            //            }
            //            else
            //            {
            //                //if (property.PropertyType != typeof(string) && property.PropertyType != typeof(int))
            //                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string) || property.PropertyType == typeof(int) || property.PropertyType == typeof(double))
            //                {
            //                    returnString = String.Concat(returnString, $"{ property.Name} : {property.GetValue(obj)} ,");

            //                }
            //                else
            //                {
            //                    if (property.GetValue(obj) != null)
            //                    {
            //                        // x = $"{ property.Name} : {JsonFormatter(property.GetValue(obj))}";
            //                        returnString = string.Concat(returnString, $"{ property.Name} : ");
            //                        returnString = string.Concat(returnString, $" {JsonFormatter(property.GetValue(obj))} ,");

            //                    }

            //                }
            //            }

            //            returnString = String.Concat(returnString, "\n");
            //        }
            //        returnString = string.Concat(returnString, "} \n");
            //    }
            //    else
            //    {
            //        returnString = string.Concat(returnString, "[\n");
            //        foreach (var i in obj as IEnumerable)
            //        {
            //            if (i.GetType().IsPrimitive || i.GetType() == typeof(string))
            //                //x = $"{i}, ";
            //            returnString = String.Concat(returnString, $"{i}, ");
            //            else
            //                //stringBuilder.Append($"{JsonFormatter(i)}, ");
            //                //x = $"{ JsonFormatter(i)}, ";
            //            returnString = String.Concat(returnString, $"{ JsonFormatter(i)}, ", "\n");
            //        }
            //        returnString = string.Concat(returnString, "] \n");
            //    }

            //    returnString = String.Concat(returnString, "}");


            //}
            //else
            //{
            //    returnString = String.Concat(returnString, $"{ obj.ToString()} ");

            //}

            //return returnString;




















            IEnumerable<PropertyInfo> properties = obj.GetType().GetProperties();

            if (!obj.GetType().IsPrimitive && obj.GetType() != typeof(string))
            {
                bool isArray = typeof(IEnumerable).IsAssignableFrom(obj.GetType()) ? true : false;

                if (isArray)
                    stringBuilder.Append($"[\n");
                else
                    stringBuilder.Append($"{{\n");

                if (!isArray)
                    foreach (var property in properties)
                    {
                        if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
                            stringBuilder.Append($"\"{property.Name}\": \"{property.GetValue(obj)}\", \n");
                        else
                        {
                            var x = property.GetValue(obj);
                            if (x != null) stringBuilder.Append($"\"{property.Name}\": {JsonFormatter(property.GetValue(obj))}, \n");
                        }
                    }

                else
                    foreach (var i in obj as IEnumerable)
                    {
                        if (i.GetType().IsPrimitive || i.GetType() == typeof(string))
                            stringBuilder.Append($"\"{i}\", ");
                        else
                            stringBuilder.Append($"{JsonFormatter(i)}, \n");
                    }


                stringBuilder.Remove(stringBuilder.ToString().Length - 2, 2);

                if (isArray)
                    stringBuilder.Append($"\n]");
                else
                    stringBuilder.Append($"\n}}");
            }
            else
                stringBuilder.Append(obj.ToString());

            //returnString = stringBuilder.ToString();
            return stringBuilder.ToString();
        }

    }
}
