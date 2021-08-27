using UnityEngine;
using UnityEngine.AI;

namespace TDSGamer.FiniteStateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(FiniteStateMachine))]
    public class EntityMover : MonoBehaviour, IAction
    {
        [Header("References")] [SerializeField]
        private Transform[] _waypoints;

        private int _waypointIndex = 0;

        private FiniteStateMachine _stateMachine;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine = GetComponent<FiniteStateMachine>();
        }

        public void MoveTo(Transform destination)
        {
            _agent.isStopped = false;
            _agent.destination = destination.position;
            _stateMachine.StartAction(this);
        }

        public void MoveToWaypoint()
        {
            _agent.isStopped = false;
            _agent.destination = _waypoints[_waypointIndex].position;
            _stateMachine.StartAction(this);

            _waypointIndex = _waypointIndex < _waypoints.Length - 1
                ? _waypointIndex + 1
                : 0;
        }

        public bool CanCancel() => true;

        public void Cancel() => _agent.isStopped = true;
    }
}