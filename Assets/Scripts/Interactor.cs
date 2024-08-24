using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private GameObject handIcon;

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 3.5f))
        {
            Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
            if (interactable != null && interactable.isInteractable)
            {
                handIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    handIcon.SetActive(false);
                }
            }
            else
            {
                handIcon.SetActive(false);
            }
        }
        else
        {
            handIcon.SetActive(false);
        }
    }
}
