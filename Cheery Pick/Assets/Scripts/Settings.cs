using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Settings : MonoBehaviour
{
    private SettingsModel _settings;
    public LangEnum Language => _settings.Language;

    private FileManager _fileManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _fileManager = FindObjectOfType<FileManager>();
        _settings = _fileManager.LoadSettings();
    }
}
