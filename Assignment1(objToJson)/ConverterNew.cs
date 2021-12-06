using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_objToJson_
{
    public class ConverterNew
    {
        private static string returnString = string.Empty;
        public static string JsonConverter<T>(T obj)
        {
            if (!obj.GetType().IsPrimitive && obj.GetType() != typeof(string))
            {
                bool isArray = typeof(IEnumerable).IsAssignableFrom(obj?.GetType()) ? true : false;
                if (!isArray)
                {
                    PropertyInfo[] properties = obj?.GetType()?.GetProperties();
                   

                    returnString = string.Concat(returnString, "{ \n");
                    if (properties?.Length > 0)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            var value = property.GetValue(obj);
                            var x = "";
                            if (value == null )
                            {
                              
                                x = (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) ? ($"{ property.Name} :" + "[]\n") : ($"{ property.Name} :" + "{}\n");
                                //returnString = string.Concat(returnString, $"{x}\n");
                            }
                            else
                            {
                                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string) || property.PropertyType == typeof(int) || property.PropertyType == typeof(double))
                                {
                                    x = $"{ property.Name} : {property.GetValue(obj)} ,\n";
                                    //returnString = String.Concat(returnString, $"{ property.Name} : {property.GetValue(obj)} ,\n");

                                }
                                else
                                {
                                    x = $"  {JsonConverter(property.GetValue(obj))} ,\n";
                                        //returnString = string.Concat(returnString, $" { property.Name} : {JsonConverter(property.GetValue(obj))} ,\n");
                                }
                            }
                            returnString = string.Concat(returnString, x);
                        }
                    }
                    else
                    {

                    }
                    returnString = string.Concat(returnString, "} \n");


                }
                //else
                //{
                //    returnString = string.Concat(returnString, "[ \n");
                //    foreach (object? i in (IEnumerable)obj)
                //    {
                //        if (i.GetType().IsPrimitive || i.GetType() == typeof(string) || i.GetType() == typeof(int) || i.GetType() == typeof(float) || i.GetType() == typeof(double))
                //            returnString = string.Concat(returnString, $"{i},", "\n");
                //        else
                //            returnString = string.Concat(returnString, $"{ JsonConverter(i)},", "\n");
                //    }
                //    returnString = string.Concat(returnString, "]\n");

                //}

            }
            return returnString;
        }
    }
}

