using UnityEngine;

namespace TDSGamer.BehaviourTree
{
    public abstract class BaseNodeAction : BaseNode
    {
        protected GameObject gameObject;
        protected Transform transform;
        private BehaviourTree owner;

        public virtual void OnStart()
        {
        }

        public virtual NodeState OnUpdate()
        {
            return NodeState.SUCCESS;
        }

        public virtual void OnLateUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual void OnEnd()
        {
        }

        public virtual void OnBehaviourComplete()
        {
        }
        
        protected T GetComponent<T>() where T : Component
        {
            return this.gameObject.GetComponent<T>();
        }

        protected Component GetComponent(System.Type type)
        {
            return this.gameObject.GetComponent(type);
        }

        protected void TryGetComponent<T>(out T component) where T : Component
        {
            this.gameObject.TryGetComponent<T>(out component);
        }

        protected void TryGetComponent(System.Type type, out Component component)
        {
            this.gameObject.TryGetComponent(type, out component);
        }

        protected GameObject GetDefaultGameObject(GameObject go)
        {
            return (UnityEngine.Object) go == (UnityEngine.Object) null ? this.gameObject : go;
        }
        
        public Transform Transform
        {
            get => this.transform;
            set => this.transform = value;
        }
        
        public GameObject GameObject
        {
            get => this.gameObject;
            set => this.gameObject = value;
        }
        
        public BehaviourTree Owner
        {
            get => this.owner;
            set => this.owner = value;
        }
    }
}