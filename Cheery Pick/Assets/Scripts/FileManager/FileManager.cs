using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static string RootFilePath { get; private set; }

    public const string SettingsFileName = "settings.json";

    public const string GameDataFileName = "gameDataX.json";
    public const int MaxGameDataFile = 3;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        RootFilePath = Application.persistentDataPath;
    }

    public static SettingsModel LoadSettings() => FileLoader.LoadSettings();
    public static GameDataModel LoadGameData(int gameDataId) => FileLoader.LoadGameData(gameDataId);
    public static List<int> GetSavedGameDataIds() => FileLoader.GetSavedGameDataIds();
}
