using System;
using UnityEngine;
using UnityEngine.AI;

namespace TDSGamer.SOFiniteStateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EntityMover : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        private int nextWayPoint;
        private NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void MoveToDestination(Transform destination, Action arrived)
        {
            agent.destination = destination.position;
            agent.isStopped = false;

            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                arrived?.Invoke();
            }
        }

        public void Travel()
        {
            MoveToDestination(waypoints[nextWayPoint], () =>
            {
                nextWayPoint = (nextWayPoint + 1) % waypoints.Length;
            });
        }
    }
}