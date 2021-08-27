using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "ActionSO_RefillBoxes", menuName = "SOFiniteStateMachine/Actions/RefillBoxesSO")]
    
    public class RefillBoxesActionSO : BaseActionSO
    {
        public override void Act(SOFiniteStateMachine machine)
        {
            machine.Consumer.RefillBoxesBehaviour();
        }
    }
}