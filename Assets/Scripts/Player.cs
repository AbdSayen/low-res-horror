using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ReadPanel readPanel;

    private PaperReader reader;

    private void Awake()
    {
        reader = new PaperReader(readPanel);
    }

    private void Update()
    {
        if (reader != null) reader.Read();
    }
}