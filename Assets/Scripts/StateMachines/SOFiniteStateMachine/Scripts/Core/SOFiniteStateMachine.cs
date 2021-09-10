using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [RequireComponent(typeof(EntityMover))]
    [RequireComponent(typeof(ConsumingBehaviour))]
    [RequireComponent(typeof(EntityStats))]
    public class SOFiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private StateSO currentStateSo;
        [SerializeField] private StateSO remainStateSo;

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
            }
        }
    }
}