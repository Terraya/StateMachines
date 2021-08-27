using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    public class SOFiniteStateMachine : MonoBehaviour
    {
        public StateSO currentStateSo;
        public StateSO remainStateSo;

        public float stateTimeElapsed;

        private EntityStats entityStats;
        private EntityMover entityMover;
        private ConsumingBehaviour consumer;
        
        public EntityMover EntityMover => entityMover;
        public ConsumingBehaviour Consumer => consumer;
        public EntityStats EntityStats => entityStats;

        private void Start()
        {
            entityMover = GetComponent<EntityMover>();
            consumer = GetComponent<ConsumingBehaviour>();
            entityStats = GetComponent<EntityStats>();
        }

        private void Update()
        {
            currentStateSo.UpdateState(this);
        }

        public void TransitionToState(StateSO nextStateSo)
        {
            if (nextStateSo != remainStateSo) 
            {
                currentStateSo = nextStateSo;
                OnExitState ();
            }
        }
        
        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }
    }
}