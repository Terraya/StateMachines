using System;

namespace TDSGamer.SOFiniteStateMachine
{
    [Serializable]
    public class Transition 
    {
        public Decision decision;
        public StateSO trueStateSo;
        public StateSO falseStateSo;
    }
}