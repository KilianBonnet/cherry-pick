using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Settings : MonoBehaviour
{
    private SettingsModel _settings;
    public LangEnum Language => _settings.Language;

    private SaveManager _saveManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _saveManager = FindObjectOfType<SaveManager>();
        _settings = _saveManager.LoadSettings();
    }
}
