using UnityEngine;

namespace TDSGamer.FiniteStateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        private IAction currentAction;

#if UNITY_EDITOR
        public string activeAction = "NaN";
        private void Update() => activeAction = currentAction == null ? "NaN" : currentAction.ToString();
#endif

        public void StartAction(IAction action)
        {
            if (action == null)
            {
                currentAction = null;
                return;
            }

            if (currentAction == action) return;

            if (currentAction != null && !currentAction.CanCancel()) return;

            currentAction?.Cancel();
            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            if (currentAction == null) return;
            if (!currentAction.CanCancel()) return;
            currentAction.Cancel();
            currentAction = null;
        }

        public void AbortCurrentAction()
        {
            currentAction.Cancel();
            currentAction = null;
        }

        public void ResetCurrentAction()
            => StartAction(null);
    }
}