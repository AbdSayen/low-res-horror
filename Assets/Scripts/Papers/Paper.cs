using UnityEngine;

public class Paper : MonoBehaviour
{
    [TextArea] public string TextRu;
    [TextArea] public string TextEn;
    public bool isReaded { get; private set; } = false;

    public void Read()
    {
        isReaded = true;
    }
}