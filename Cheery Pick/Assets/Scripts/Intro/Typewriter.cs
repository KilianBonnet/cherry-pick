using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class Typewriter : MonoBehaviour
{
    [Tooltip("Time between two characters.")]
    [SerializeField] private float _characterDelta = .2f;

    private TextMeshProUGUI _textUi;
    private AudioSource _typewriterAudio;

    private void Start()
    {
        _textUi = GetComponent<TextMeshProUGUI>();
        _typewriterAudio = GetComponent<AudioSource>();
    }

    public void Type(string text, Action onComplete)
    {
        StartCoroutine(TypeCoroutine(text, onComplete));
    }

    private IEnumerator TypeCoroutine(string text, Action onComplete)
    {
        _textUi.text = "";

        foreach (char letter in text)
        {
            _typewriterAudio.Play();
            _textUi.text += letter;
            yield return new WaitForSeconds(_characterDelta);
        }

        onComplete?.Invoke();
    }
}
