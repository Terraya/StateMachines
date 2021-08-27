using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "TravelSO", menuName = "SOFiniteStateMachine/Actions/TravelSO")]
    public class TravelActionSO : BaseActionSO
    {
        public override void Act(SOFiniteStateMachine machine)
        {
            machine.EntityMover.Travel();
        }
    }
}