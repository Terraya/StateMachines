using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    public abstract class BaseDecisionSO : ScriptableObject
    {
        public abstract bool Decide (SOFiniteStateMachine machine);
    }
}