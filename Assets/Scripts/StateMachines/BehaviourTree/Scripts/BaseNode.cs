using System;

namespace TDSGamer.BehaviourTree
{
    [Serializable]
    public abstract class BaseNode
    {
        protected NodeState _nodeState;
        public NodeState NodeState
        {
            get => _nodeState;
            set => _nodeState = value;
        }
    }

    public enum NodeState
    {
        INACTIVE,
        FAILURE,
        SUCCESS,
        RUNNING,
    }   
}