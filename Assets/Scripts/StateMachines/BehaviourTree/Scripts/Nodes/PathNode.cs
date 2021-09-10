using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TDSGamer.BehaviourTree
{
    public class PathNode : BaseNodeAction
    {
        private NavMeshAgent agent;
        private List<Transform> waypoints;
        private int waypointIndex = 0;
        
        public PathNode(NavMeshAgent agent, List<Transform> waypoints)
        {
            this.agent = agent;
            this.waypoints = waypoints;
        }

        public override void OnStart()
        {
            throw new NotImplementedException();
        }

        public override NodeState OnUpdate()
        {
            throw new NotImplementedException();
        }

        public override void OnEnd()
        {
            throw new NotImplementedException();
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
    }
}