using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "DecisionSO_Healthy", menuName = "SOFiniteStateMachine/Decisions/HealthySO")]
    public class HealthyDecisionSO : BaseDecisionSO
    {
        public override bool Decide(SOFiniteStateMachine machine)
        {
            bool isHealthy = machine.EntityStats.IsHealthy();
            return isHealthy;
        }
    }
}