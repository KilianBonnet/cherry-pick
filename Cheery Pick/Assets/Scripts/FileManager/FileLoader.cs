using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class FileLoader
{
    /// <summary>
    /// Try load the SettingsModel from persistent memory.
    /// If the load fail, it will return the default SettingsModel.
    /// </summary>
    /// <returns>The loaded SettingsModel</returns>
    public static SettingsModel LoadSettings()
    {
        try { return Load<SettingsModel>(FileManager.SettingsFileName); }
        catch (Exception e)
        {
            Debug.LogWarning($"{e.Message} Loading default SettingsModel.");
            return new();
        }
    }

    /// <summary>
    /// Try load the GameDataModel from persistent memory.
    /// If the load fail, it will return null.
    /// </summary>
    /// <param name="gameDataId">The if of the GameDataModel to load.</param>
    /// <returns>The loaded SettingsModel</returns>
    public static GameDataModel LoadGameData(int gameDataId)
    {
        string fileName = FileManager.GameDataFileName.Replace("X", gameDataId.ToString());

        try { return Load<GameDataModel>(fileName); }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }


    /// <summary>
    /// Check if a game data file exists with the given game data id.
    /// </summary>
    /// <param name="gameDataId">The game data id to check if a file exists.</param>
    /// <returns>Whether or not the game data file exists.</returns>
    public static bool HasSavedGameData(int gameDataId)
    {
        string fileName = FileManager.GameDataFileName.Replace("X", gameDataId.ToString());
        string filePath = Path.Combine(FileManager.RootFilePath, fileName);
        return File.Exists(filePath);
    }

    /// <summary>
    /// Load a T model from a specific fileName.
    /// </summary>
    /// <typeparam name="T">The class of the model to load.</typeparam>
    /// <param name="fileName">The name of the file in the prescient memory.</param>
    /// <returns>The loaded model.</returns>
    private static T Load<T>(string fileName)
    {
        string filePath = Path.Combine(FileManager.RootFilePath, fileName);
        string modelName = typeof(T).Name;

        if (File.Exists(filePath))
        {
            Debug.Log($"Loading {modelName} from {fileName}...");
            try
            {
                string json = File.ReadAllText(filePath);
                T model = JsonConvert.DeserializeObject<T>(json);
                Debug.Log($"{modelName} loaded successfully.");
                return model;
            }
            catch { throw new($"An error occurred when reading {fileName}."); }
        }
        else { throw new($"Cannot find {fileName}."); }
    }
}