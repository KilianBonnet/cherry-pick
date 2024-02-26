using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private string _newGameSceneName = "IntroScene";

    public void LoadGame(int gameDataId)
    {
        SaveManager saveManager = FindAnyObjectByType<SaveManager>();
        GameDataModel gameDataModel = saveManager.LoadGameData(gameDataId);
    }

    public void StartNewGame()
    {
        GameDataModel gameDataModel = new();
        SceneManager.LoadScene(_newGameSceneName);
    }

}
