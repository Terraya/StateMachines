using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    public abstract class BaseActionSO : ScriptableObject
    {
        public abstract void Act(SOFiniteStateMachine machine);
    }
}