﻿namespace TDSGamer.SOAdvStateMachine
{
    public interface IStateComponent
    {
        /// <summary>
        /// Called when entering the state.
        /// </summary>
        void OnStateEnter();

        /// <summary>
        /// Called when leaving the state.
        /// </summary>
        void OnStateExit();
    }
}