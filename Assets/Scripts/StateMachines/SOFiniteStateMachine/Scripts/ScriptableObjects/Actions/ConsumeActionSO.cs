using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "ConsumeSO", menuName = "SOFiniteStateMachine/Actions/ConsumeSO")]
    public class ConsumeActionSO : BaseActionSO
    {
        public override void Act(SOFiniteStateMachine machine)
        {
            machine.Consumer.ConsumeBehaviour();
        }
    }   
}
