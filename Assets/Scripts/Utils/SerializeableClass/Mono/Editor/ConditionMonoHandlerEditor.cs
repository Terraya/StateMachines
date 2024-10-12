using System;
using UnityEditor;

namespace Utils.Editor
{
    [CustomEditor(typeof(ConditionMonoHandler))]
    public class ConditionMonoHandlerEditor : UnityEditor.Editor
    {
        private ConditionMonoHandler _monoHandler => target as ConditionMonoHandler;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawSelectedAction(_monoHandler);
        }

        private void DrawSelectedAction(ConditionMonoHandler currentMonoHandler)
        {
            _monoHandler.a ??= new BaseMonoAction();

            BaseMonoAction expectedMonoAction = ConditionCache.FindByAction(currentMonoHandler.CurrentAction);
            Type currentActionType = _monoHandler.a.GetType();

            if (expectedMonoAction.GetType() == currentActionType) return;

            _monoHandler.a = Helper.CreateInstance(expectedMonoAction);
        }
    }
}