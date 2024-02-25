using System.Collections;
using UnityEngine;

public class ExitSignBlink : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Light _light;
    [SerializeField] private Material _signEmissionMaterial;
    [SerializeField] private AudioSource _audioSource;

    [Header("Blink delta")]
    [Tooltip("Minimum time (in sec.) between two blinks.")]
    [SerializeField] private float _minBlinkDelta = 10;

    [Tooltip("Minimum time (in sec.) between two blinks.")]
    [SerializeField] private float _maxBlinkDelta = 30;

    [Header("Blink duration")]
    [Tooltip("How long (in sec.) the blink last in minimum.")]
    [SerializeField] private float _minBlinkDuration = .1f;

    [Tooltip("How long (in sec.) the blink last in maximum.")]
    [SerializeField] private float _maxBlinkDuration = .2f;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            float timeToWait = Random.Range(_minBlinkDelta, _maxBlinkDelta);
            yield return new WaitForSeconds(timeToWait);
            SetLightState(false);
            timeToWait = Random.Range(_minBlinkDuration, _maxBlinkDuration);
            yield return new WaitForSeconds(timeToWait);
            SetLightState(true);
        }

    }

    private void SetLightState(bool state)
    {
        _light.enabled = state;

        if (state)
        {
            _audioSource.Play();
            _signEmissionMaterial.EnableKeyword("_EMISSION");
        }
        else _signEmissionMaterial.DisableKeyword("_EMISSION");
    }
}
