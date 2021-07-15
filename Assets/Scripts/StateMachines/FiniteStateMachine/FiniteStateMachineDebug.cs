using UnityEngine;

namespace TDSGamer.FiniteStateMachine
{
    public class FiniteStateMachineDebug : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Debug")]
        public string activeAction;
        public string oldAction;
#endif

        private IAction currentAction;

        public void StartAction(IAction action)
        {
            if (action == null)
            {
                currentAction = null;
#if UNITY_EDITOR
                oldAction = activeAction;
                activeAction = null; 
#endif
                return;
            }

            if (currentAction == action) return;

            if (currentAction != null && !currentAction.CanCancel()) return;

            if (currentAction != null)
            {
#if UNITY_EDITOR
                oldAction = currentAction.ToString();
#endif
                currentAction.Cancel();
            }

#if UNITY_EDITOR
            activeAction = action.ToString();
#endif
            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            if (currentAction == null) return;
            currentAction.Cancel();
#if UNITY_EDITOR
            oldAction = activeAction;
            activeAction = null;
#endif
            currentAction = null;
        }

        public void ResetCurrentAction()
            => StartAction(null);
    }
}