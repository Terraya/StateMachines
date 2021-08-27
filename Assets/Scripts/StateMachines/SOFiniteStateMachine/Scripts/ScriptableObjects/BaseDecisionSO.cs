using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide (SOFiniteStateMachine machine);
    }
}