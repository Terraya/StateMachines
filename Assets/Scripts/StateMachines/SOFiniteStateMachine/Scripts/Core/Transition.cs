using System;

namespace TDSGamer.SOFiniteStateMachine
{
    [Serializable]
    public class Transition 
    {
        public BaseDecisionSO baseDecisionSo;
        public StateSO trueStateSo;
        public StateSO falseStateSo;
    }
}
