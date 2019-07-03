using System;
using System.Reflection;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class TypeExtensions
    {
        public static Assembly GetAssembly(this Type type)
        {
            return Assembly.GetAssembly(type);
        }
    }
}