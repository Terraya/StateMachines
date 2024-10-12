namespace TDSGamer.SOAdvStateMachine
{
    public readonly struct StateCondition
    {
        internal readonly StateMachine _stateMachine;
        internal readonly Condition _condition;
        internal readonly bool _expectedResult;

        public StateCondition(StateMachine stateMachine, Condition condition, bool expectedResult)
        {
            _stateMachine = stateMachine;
            _condition = condition;
            _expectedResult = expectedResult;
        }

        /// <summary>
        /// Checking if the current running condition is equal the result we are expecting to get back
        /// </summary>
        /// <returns></returns>
        public bool IsMet()
        {
            bool statement = _condition.GetStatement();
            bool isMet = statement == _expectedResult;

#if UNITY_EDITOR
            _stateMachine._debugger.TransitionConditionResult(_condition._originSO.name, statement, isMet);
#endif
            return isMet;
        }
    }
}