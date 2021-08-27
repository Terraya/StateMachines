using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "DecisionSO_Boxes", menuName = "SOFiniteStateMachine/Decisions/BoxesSO")]
    public class BoxesDecisionSO : Decision
    {
        public override bool Decide(SOFiniteStateMachine machine)
        {
            bool needRefill = machine.Consumer.EnoughBoxes();
            return needRefill;
        }
    }   
}
