using TDSGamer.SOAdvStateMachine.ScriptableObjects;
using UnityEngine;

namespace TDSGamer.SOAdvStateMachine
{
    [CreateAssetMenu(fileName = "LogAction", menuName = "SOAdvStateMachine/Action/CustomLogAction")]
    public class CustomLogActionSO : StateActionSO
    {
        protected override StateAction CreateAction() => new CustomLogAction();
    }

    public class CustomLogAction : StateAction
    {
        public override void OnUpdate()
        {
            Debug.Log("Running Custom Log Action");
        }
    }
}