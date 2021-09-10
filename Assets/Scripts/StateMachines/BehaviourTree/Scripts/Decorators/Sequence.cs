using System.Collections.Generic;

namespace TDSGamer.BehaviourTree
{
    public class Sequence : BaseDecorator
    {
        public Sequence(List<BaseNode> nodes)
        {
            this.nodes = nodes;
        }

        public override NodeState OnUpdate()
        {
            foreach (BaseNodeAction node in nodes)
            {
                switch (node.OnUpdate())
                {
                    case NodeState.RUNNING:
                        return NodeState.RUNNING;
                    case NodeState.SUCCESS:
                        break;
                    case NodeState.FAILURE:
                        return NodeState.FAILURE;
                    default:
                        break;
                }
            }
            return NodeState.FAILURE;
        }
    }   
}