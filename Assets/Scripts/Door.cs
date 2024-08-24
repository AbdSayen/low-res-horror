using System.Collections;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool canBeOpened = true;
    [SerializeField] private bool isRight = false;
    public bool isOpened { get; private set; } = false;
    private bool isInProcess = false;

    public override void Interact()
    {
        if (!isInProcess)
        {
            if (canBeOpened)
            {
                StartCoroutine(OpenDoor());
            }
            else
            {
                Game.PushMessage(this, Translator.GetTranslate("Дверь не может быть открыта", "The door cannot be opened"), 1.5f);
            }
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
                if (isRight)
                {
                    transform.rotation *= Quaternion.Euler(0, -1, 0);
                } else transform.rotation *= Quaternion.Euler(0, 1, 0);

                yield return new WaitForSeconds(duration);
            }
            isOpened = true;
        }
        else
        {
            for (int i = 0; i < angle; i++)
            {   
                if (isRight)
                {
                    transform.rotation *= Quaternion.Euler(0, 1, 0);
                }
                else transform.rotation *= Quaternion.Euler(0, -1, 0);
                yield return new WaitForSeconds(duration);
            }
            isOpened = false;
        }

        isInProcess = false;
    }
}