using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool isInteractable { get; private set; } = true;

    public abstract void Interact();
}
