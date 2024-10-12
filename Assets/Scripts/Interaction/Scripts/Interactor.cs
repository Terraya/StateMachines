using System;
using UnityEngine;

namespace Interaction.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class Interactor : MonoBehaviour
    {
#if UNITY_EDITOR
        public InteractorDebugger _debugger;
#endif
        private const float _maxDistance = 10f;

        private IInteractable _interactableTarget;
        private IInteractable _currentInteractable;

        private RaycastHit _hitDetect;
        private Collider _collider;

        public static Action<IIdentity> OnNewTarget;
        public static Action OnInteract;
        public static Action OnEmptyTarget;

        private void Awake()
        {
#if UNITY_EDITOR
            _debugger = new InteractorDebugger();
#endif

            _hitDetect = new RaycastHit();
            _collider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StopInteracting();

            if (IsInteracting()) return;

            if (Physics.BoxCast(_collider.bounds.center, transform.localScale, transform.forward, out _hitDetect, transform.rotation, _maxDistance))
            {
#if UNITY_EDITOR
                _debugger.RaycastTarget = _hitDetect.collider.gameObject;
#endif
                // Check if the hit object has the "IInteractable" component
                IInteractable interactable = _hitDetect.collider.gameObject.GetComponent<IInteractable>();
                
                if (interactable != null)
                {
#if UNITY_EDITOR
                    _debugger.PossibleInteractableTarget = _hitDetect.collider.gameObject;
#endif
                    
                    if (_interactableTarget != interactable)
                    {
                        // Show interaction prompt for new interactable
                        OnNewTarget?.Invoke(_hitDetect.collider.gameObject.GetComponent<IIdentity>());
                        _interactableTarget = interactable;
                    }

                    // Check for interaction input
                    if (Input.GetKeyDown(KeyCode.E))
                    {
#if UNITY_EDITOR
                        _debugger.CurrentInteractable = _hitDetect.collider.gameObject;
#endif
                        _currentInteractable = interactable;
                        _currentInteractable.Interact(gameObject);
                        // Hide interaction prompt for previous interactable
                        OnInteract?.Invoke();
                    }
                }
                else
                {
#if UNITY_EDITOR
                    _debugger.PossibleInteractableTarget = null;
#endif
                    _interactableTarget = null;
                }
            }
            else
            {
#if UNITY_EDITOR
                _debugger.RaycastTarget = null;
#endif
                _interactableTarget = null;
                OnEmptyTarget?.Invoke();
            }
        }

        private bool IsInteracting()
        {
            return _currentInteractable != null && _currentInteractable.IsInteractingWith(gameObject);
        }
        
        private void StopInteracting()
        {
            if (_currentInteractable == null)
                return;

#if UNITY_EDITOR
            _debugger.CurrentInteractable = null;
#endif

            _currentInteractable.StopInteract();
            _currentInteractable = null;
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * _maxDistance, transform.localScale);
        }
#endif
    }
}