using System.Collections.Generic;

namespace TDSGamer.BehaviourTree
{
    public abstract class BaseDecorator : BaseNodeAction
    {
        protected List<BaseNode> nodes = new List<BaseNode>();
        public List<BaseNode> Nodes
        {
            get => nodes;
            set => nodes = value;
        }
    }
}