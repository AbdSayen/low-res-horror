using System.Collections;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool canBeOpened = true;
    public bool isOpened { get; private set; } = false;
    private bool isInProcess = false;

    public override void Interact(object[] props = null)
    {
        if (!isInProcess)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        isInProcess = true;
        float angle = 90f;
        float duration = 0.0035f;

        if (!isOpened)
        {
            for (int i = 0; i < angle; i++)
            {
                transform.rotation *= Quaternion.Euler(0, 1, 0);
                yield return new WaitForSeconds(duration);
            }
            isOpened = true;
        }
        else
        {
            for (int i = 0; i < angle; i++)
            {
                transform.rotation *= Quaternion.Euler(0, -1, 0);
                yield return new WaitForSeconds(duration);
            }
            isOpened = false;
        }

        isInProcess = false;
    }
}