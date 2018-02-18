using System;

namespace MvvmFx.Bindings
{
    internal static class Assert
    {
        internal static void GenericArgumentNotNull<T>(T arg, string argName)
        {
            Type type = typeof (T);

            if (!type.IsValueType || (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof (Nullable<>))))
            {
                if (arg == null)
                {
                    throw new ArgumentNullException(argName);
                }
            }
        }
    }
}
