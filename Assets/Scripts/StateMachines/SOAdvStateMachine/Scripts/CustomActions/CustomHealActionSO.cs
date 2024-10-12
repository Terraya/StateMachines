using TDSGamer.SOAdvStateMachine;
using TDSGamer.SOAdvStateMachine.ScriptableObjects;
using TDSGamer.SOAdvStateMachine.TestingGround;
using UnityEngine;

namespace StateMachines.SOAdvStateMachine
{
    [CreateAssetMenu(fileName = "Heal Action", menuName = "SOAdvStateMachine/Action/CustomHealAction")]
    public class CustomHealActionSO : StateActionSO
    {
        protected override StateAction CreateAction() => new CustomHealAction();
    }

    public class CustomHealAction : StateAction
    {
        private EntityHealth _entityHealth;

        public override void Awake(StateMachine stateMachine)
        {
            _entityHealth = stateMachine.GetComponent<EntityHealth>();
        }

        public override void OnUpdate()
        {
            _entityHealth.Heal(10 * Time.deltaTime);
        }
    }
}