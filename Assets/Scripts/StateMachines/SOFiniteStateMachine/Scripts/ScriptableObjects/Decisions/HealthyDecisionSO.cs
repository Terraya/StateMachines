using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "DecisionSO_Healthy", menuName = "SOFiniteStateMachine/Decisions/HealthySO")]
    public class HealthyDecisionSO : Decision
    {
        public override bool Decide(SOFiniteStateMachine machine)
        {
            bool isHealthy = machine.EntityStats.IsHealthy();
            return isHealthy;
        }
    }
}