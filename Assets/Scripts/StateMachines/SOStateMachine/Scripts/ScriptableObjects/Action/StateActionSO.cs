using System.Collections.Generic;
using UnityEngine;

namespace TDSGamer.SOStateMachine
{
    public abstract class StateActionSO : ScriptableObject
    {
        internal StateAction GetAction(SOStateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj))
                return (StateAction)obj;

            StateAction action = CreateAction();
            createdInstances.Add(this, action);
            action._originSO = this;
            action.Awake(stateMachine);
            return action;
        }
        protected abstract StateAction CreateAction();
    }
    
    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
    {
        protected override StateAction CreateAction() => new T();
    }
}