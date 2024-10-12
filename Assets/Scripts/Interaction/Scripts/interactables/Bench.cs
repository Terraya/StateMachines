using UnityEngine;

namespace Interaction.Scripts
{
    public class Bench : MonoBehaviour, IInteractable, IIdentity
    {
        private const string _identity = "Bench";

        private GameObject _interactingWith;

        public void Interact(GameObject interactor)
        {
            _interactingWith = interactor;
            print($"Intercting with {interactor.name}");
        }

        public void StopInteract()
        {
            print("Stop Interact");
            _interactingWith = null;
        }

        public bool IsInteractingWith(GameObject interactor)
        {
            if (!_interactingWith)
                return false;

            return _interactingWith == interactor;
        }

        public string GetIdentity()
        {
            return _identity;
        }
    }
}