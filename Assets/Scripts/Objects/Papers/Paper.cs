using UnityEngine;

public class Paper : Interactable
{
    [TextArea] public string TextRu;
    [TextArea] public string TextEn;
    public bool isReaded { get; private set; } = false;

    public override void Interact()
    {
        GameObject.FindGameObjectWithTag("ReadPanel").GetComponent<ReadPanel>().Open(Game.language == Language.ru ? TextRu : TextEn);
        Read();
    }

    private void Read()
    {
        isReaded = true;
    }
}
