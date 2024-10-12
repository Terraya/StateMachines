using TDSGamer.SOAdvStateMachine;
using TDSGamer.SOAdvStateMachine.ScriptableObjects;
using TDSGamer.SOAdvStateMachine.TestingGround;
using UnityEngine;

namespace StateMachines.SOAdvStateMachine.TestingGround
{
    [CreateAssetMenu(fileName = "Health Condition", menuName = "SOAdvStateMachine/Condition/CustomHealthCheckCondition")]
    public class CustomHealthConditionSO : StateConditionSO
    {
        protected override TDSGamer.SOAdvStateMachine.Condition CreateCondition() => new CustomHealthCondition();
    }

    public class CustomHealthCondition : TDSGamer.SOAdvStateMachine.Condition
    {
        private EntityHealth _entityHealth;

        public override void Awake(StateMachine stateMachine)
        {
            _entityHealth = stateMachine.GetComponent<EntityHealth>();
        }

        protected override bool Statement()
        {
            bool isHealthy = _entityHealth.CurrentHealth >= 50;
            
            Debug.Log($"Health expecting: false, state: {isHealthy}");
            
            return isHealthy;
        }
    }
}