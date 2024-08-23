using UnityEngine;

public class Paper : Interactable
{
    [TextArea] public string TextRu;
    [TextArea] public string TextEn;
    public bool isReaded { get; private set; } = false;

    public override void Interact(object[] props = null)
    {
        Read();
    }

    private void Read()
    {
        isReaded = true;
    }
}
