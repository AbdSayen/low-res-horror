using UnityEngine;
using UnityEngine.UI;

public class ReadPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text text;

    public void Open(string text)
    {
        panel.SetActive(true);
        this.text.text = text;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().cameraCanMove = false;
    }

    public void Close()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().cameraCanMove = true;
    }
}