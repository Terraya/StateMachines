using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [CreateAssetMenu(fileName = "State", menuName = "SOFiniteStateMachine/State")]
    public class StateSO : ScriptableObject
    {
        public BaseActionSO[] actions;
        public Transition[] transitions;

        public void UpdateState(SOFiniteStateMachine machine)
        {
            DoActions (machine);
            CheckTransitions (machine);
        }

        private void DoActions(SOFiniteStateMachine machine)
        {
            for (int i = 0; i < actions.Length; i++) {
                actions [i].Act (machine);
            }
        }

        private void CheckTransitions(SOFiniteStateMachine machine)
        {
            for (int i = 0; i < transitions.Length; i++) 
            {
                bool decisionSucceeded = transitions [i].decision.Decide (machine);

                if (decisionSucceeded) {
                    machine.TransitionToState (transitions [i].trueStateSo);
                } else 
                {
                    machine.TransitionToState (transitions [i].falseStateSo);
                }
            }
        }
    }
}