using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
    private Text text;
    private string lang;

    [SerializeField] [TextArea] private string EnText;
    [SerializeField] [TextArea] private string RuText;

    private void Start()
    {
        text = GetComponent<Text>();

        switch (Game.language)
        {
            case Language.ru:
                text.text = RuText;
                break;
            case Language.en:
                text.text = EnText;
                break;
            default:
                break;
        }
    }

    static public string GetTranslate(string ru, string en)
    {
        switch (Game.language)
        {
            case Language.ru:
                return ru;
            case Language.en:
                return en;
            default:
                return "Unregistered language";
        }
    }
}