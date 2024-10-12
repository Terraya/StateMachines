using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Utils;

public class ConditionHandlerDemo : MonoBehaviour
{
    public TAction Action;

    private void Start()
    {
        Action.food.Action();
    }

    private void LogSubclasses()
    {
        foreach (Type type in Assembly.GetAssembly(typeof(BaseFood)).GetTypes()
            .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(BaseFood))))
        {
            var instance = Activator.CreateInstance(type);
            var tempFood = (BaseFood) instance;
        }
    }
}

[Serializable]  
public class TAction
{
    [SerializeReference, SelectImplementation(typeof(BaseFood))]
    public BaseFood food;
}