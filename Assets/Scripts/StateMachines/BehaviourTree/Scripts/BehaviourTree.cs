using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TDSGamer.BehaviourTree
{
    public class BehaviourTree : MonoBehaviour
    {
        [Header("BehaviourTree Setup")] 
        [SerializeField] private bool startWhenEnabled;
        
        // BehaviourTree Nodes
        private List<BaseNode> nodes = new List<BaseNode>();

        // Necessary Values for the Nodes examp: Component<NavMeshAgent>
        private Dictionary<BaseNode, Dictionary<string, object>> defaultValues;

        private void Start()
        {
            if (!this.startWhenEnabled)
                return;
            
        }

        private IEnumerator loop()
        {
            yield return new WaitForFixedUpdate();
            
        }

        private IEnumerator asd()
        {
            yield return new TimeUpdate();
        }
    }
}