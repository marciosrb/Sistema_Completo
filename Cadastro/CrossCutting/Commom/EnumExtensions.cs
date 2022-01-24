using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CQRS.CrossCutting.Commom
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(T enumValue)
        {
            return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description ?? string.Empty;
        }
        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
              foreach (var field in typeof(T).GetFields())
              {
                  if (Attribute.GetCustomAttribute(field,
                  typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                  {
                      if (attribute.Description == description)
                      return (T)field.GetValue(null);
                  }
                  else
                  {
                  if (field.Name == description)
                  return (T)field.GetValue(null);
                  }                  
              } 
            return default(T);           
        }
    }
}