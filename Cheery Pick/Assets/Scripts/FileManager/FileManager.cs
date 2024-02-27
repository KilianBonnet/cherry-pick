using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static string RootFilePath => Application.persistentDataPath;

    public const string SettingsFileName = "settings.json";

    public const string GameDataFileName = "gameDataX.json";
    public const int MaxGameDataFile = 3;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public SettingsModel LoadSettings() => FileLoader.LoadSettings();
    public GameDataModel LoadGameData(int gameDataId) => FileLoader.LoadGameData(gameDataId);
    public bool HasSavedGameDataId(int gameDataId) => FileLoader.HasSavedGameData(gameDataId);
}
