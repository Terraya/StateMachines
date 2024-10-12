using TDSGamer.SOAdvStateMachine.ScriptableObjects;

namespace TDSGamer.SOAdvStateMachine
{
    public class State
    {
        // The StateSO to which this State determs, its Origin
        internal StateSO _originSO;
        // StateMachine to which this State belong to
        internal StateMachine _stateMachine;
        // Possible transitions to which we can transit from current state
        internal StateTransition[] _transitions;
        // Actions which get executed in Update
        internal StateAction[] _actions;

        internal State() { }
        public State(StateSO originSo, StateMachine stateMachine, StateTransition[] transitions, StateAction[] actions)
        {
            _originSO = originSo;
            _stateMachine = stateMachine;
            _transitions = transitions;
            _actions = actions;
        }

        public void OnStateEnter()
        {
            OnStateEnter(_transitions);
            OnStateEnter(_actions);
        }

        private void OnStateEnter(IStateComponent[] comps)
        {
            for (int i = 0; i < comps.Length; i++)
                comps[i].OnStateEnter();
        }
        
        public void OnUpdate()
        {
            for (int i = 0; i < _actions.Length; i++)
                _actions[i].OnUpdate();
        }

        public void OnStateExit()
        {
            OnStateExit(_transitions);
            OnStateExit(_actions);
        }

        private void OnStateExit(IStateComponent[] comps)
        {
            for (int i = 0; i < comps.Length; i++)
                comps[i].OnStateExit();
        }
        
        // TODO CHECK FOR ITS USABILITY
        public bool TryGetTransition(out State state)
        {
            state = null;

            for (int i = 0; i < _transitions.Length; i++)
                if (_transitions[i].TryGetTransiton(out state))
                    break;

            for (int i = 0; i < _transitions.Length; i++)
                _transitions[i].ClearConditionsCache();

            return state != null;
        }
    }
}