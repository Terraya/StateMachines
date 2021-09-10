using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    public class FoodStand : MonoBehaviour
    {
        [Header("FoodStand Setup")] 
        [SerializeField] private Transform moveToPosition;
        public Transform MoveToPosition => moveToPosition;
        
        [Header("FoodStand Settings")] 
        [SerializeField] private float healthRecover;
        public float HealthRecover => healthRecover;

#if UNITY_EDITOR
        [Header("Gizmos Setup")]
        public bool showGizmos = false;
        public float gizmoSize = 0.4f;

        private void OnDrawGizmos()
        {
            if (showGizmos == false) return;
            Gizmos.DrawSphere(moveToPosition.position, gizmoSize);
        }
#endif
    }
}