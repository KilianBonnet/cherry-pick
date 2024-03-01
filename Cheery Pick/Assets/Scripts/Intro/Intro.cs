using UnityEngine;

public class Intro : MonoBehaviour
{
    private Typewriter _typewriter;

    private void Start()
    {
        _typewriter = FindObjectOfType<Typewriter>();
    }

    private void OnLocalizationLoaded(string text)
    {

    }
}
