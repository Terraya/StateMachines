using TDSGamer.SOAdvStateMachine.ScriptableObjects;

namespace TDSGamer.SOAdvStateMachine
{
    public abstract class Condition : IStateComponent
    {
        private bool _isCached = false;
        private bool _cachedStatement = default;
        internal StateConditionSO _originSO;

        protected StateConditionSO OriginSO => _originSO;

        // The Statement which is actualy running, example: "Is this character dead? Health <= 0 return true"
        protected abstract bool Statement();

        internal bool GetStatement()
        {
            if (!_isCached)
            {
                _isCached = true;
                _cachedStatement = Statement();
            }

            return _cachedStatement;
        }

        internal void ClearStatementCache()
        {
            _isCached = false;
        }

        // Awake is called when creating a new instance. Method is still used to cache the component needed for this condition
        public virtual void Awake(StateMachine stateMachine) { }
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
    }
}