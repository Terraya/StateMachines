using System;

public class Helper
{
    public static T CreateInstance<T>(T instance) where T : IBaseAction, new()
    {
        T newInstance = (T) Activator.CreateInstance(instance.GetType());
        return newInstance;
    }
}