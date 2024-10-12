using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactor);
    void StopInteract();
    bool IsInteractingWith(GameObject interactor);
}
