using System;
using System.Collections.Generic;
using TDSGamer.SOAdvStateMachine.ScriptableObjects;
using UnityEngine;
using UnityEngine.Rendering;

namespace TDSGamer.SOAdvStateMachine
{
    public class StateMachine : MonoBehaviour
    {
        // Initial State of the State Machine
        [SerializeField] private TransitionTableSO _transitionTableSO = default;
        
#if UNITY_EDITOR
        [Space]
        [SerializeField]
        internal StateMachineDebugger _debugger = default;
#endif
        
        // Components which are needed by ea. Node in the State Machine, get cached inside the Dictionary
        private SerializedDictionary<Type, Component> _cachedComponents = new SerializedDictionary<Type, Component>();
        // Current State
        internal State _currentState;

        private void Awake()
        {
            _currentState = _transitionTableSO.GetInitialState(this);
#if UNITY_EDITOR
            _debugger.Awake(this);
#endif
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            UnityEditor.AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
        }

        private void OnAfterAssemblyReload()
        {
            _currentState = _transitionTableSO.GetInitialState(this);
            _debugger.Awake(this);
        }

        private void OnDisable()
        {
            UnityEditor.AssemblyReloadEvents.afterAssemblyReload -= OnAfterAssemblyReload;
        }
#endif
        
        private void Start()
        {
            _currentState.OnStateEnter();
        }
        
        public new bool TryGetComponent<T>(out T component) where T : Component
        {
            var type = typeof(T);
            if (!_cachedComponents.TryGetValue(type, out var value))
            {
                if (base.TryGetComponent<T>(out component))
                    _cachedComponents.Add(type, component);

                return component != null;
            }

            component = (T)value;
            return true;
        }

        private void Update()
        {
            if (_currentState.TryGetTransition(out var transitionState))
                Transition(transitionState);

            _currentState.OnUpdate();
        }

        private void Transition(State transitionState)
        {
            _currentState.OnStateExit();
            _currentState = transitionState;
            _currentState.OnStateEnter();
        }
    }   
}