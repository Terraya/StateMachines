using System.Collections.Generic;

namespace TDSGamer.BehaviourTree
{
    public class Selector : BaseDecorator
    {
        public Selector(List<BaseNode> nodes)
        {
            this.nodes = nodes;
        }

        public override NodeState OnUpdate()
        {
            foreach (BaseNodeAction node in Nodes)
            {
                switch (node.OnUpdate())
                {
                    case NodeState.RUNNING:
                        return NodeState.RUNNING;
                    case NodeState.SUCCESS:
                        return NodeState.SUCCESS;
                    case NodeState.FAILURE:
                        break;
                    default:
                        break;
                }
            }
            return NodeState.FAILURE;
        }
    }   
}