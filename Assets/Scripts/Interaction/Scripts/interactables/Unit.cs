using UnityEngine;

namespace Interaction.Scripts
{
    public class Unit: MonoBehaviour, IInteractable, ILivingIdentity
    {
        private const string _identity = "Unit";

        private float _maxHealth = 100f;
        private float _health = 39f;
        
        private GameObject _interactingWith;

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

        public float GetHealth()
        {
            return _health;
        }

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