using System;
using UnityEngine;

namespace Interaction.Scripts
{
    [Serializable]
    public class InteractorDebugger
    {
        public GameObject PossibleInteractableTarget;
        public GameObject RaycastTarget;
        public GameObject CurrentInteractable;
    }
}