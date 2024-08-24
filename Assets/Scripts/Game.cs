using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Language _language;
    static public Language language;

    private void Awake()
    {
        language = _language;
    }
}

public enum Language 
{
    en, ru
}