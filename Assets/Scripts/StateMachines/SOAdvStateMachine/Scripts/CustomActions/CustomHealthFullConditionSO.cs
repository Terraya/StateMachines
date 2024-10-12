using TDSGamer.SOAdvStateMachine;
using TDSGamer.SOAdvStateMachine.ScriptableObjects;
using TDSGamer.SOAdvStateMachine.TestingGround;
using UnityEngine;

namespace StateMachines.SOAdvStateMachine.TestingGround
{
    [CreateAssetMenu(fileName = "Health Condition", menuName = "SOAdvStateMachine/Condition/CustomFullHealthCheckCondition")]
    public class CustomHealthFullConditionSO : StateConditionSO
    {
        protected override TDSGamer.SOAdvStateMachine.Condition CreateCondition() => new CustomHealthFullCondition();
    }

    public class CustomHealthFullCondition : TDSGamer.SOAdvStateMachine.Condition
    {
        private EntityHealth _entityHealth;

        public override void Awake(StateMachine stateMachine)
        {
            _entityHealth = stateMachine.GetComponent<EntityHealth>();
        }

        protected override bool Statement()
        {
            bool isHealthy = _entityHealth.CurrentHealth >= 100;
            
            Debug.Log($"Full Health expecting: true, state: {isHealthy}");
            
            return isHealthy;
        }
    }
}