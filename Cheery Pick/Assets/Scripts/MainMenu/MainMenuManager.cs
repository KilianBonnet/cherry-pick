using System.Linq;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    private void Start()
    {
        SetupGameDataButtons();
    }

    private void SetupGameDataButtons()
    {
        FileManager fileManager = FindAnyObjectByType<FileManager>();
        GameDataButton[] gameDataButtons = FindObjectsOfType<GameDataButton>();

        foreach (int gameDataId in fileManager.GetSavedGameDataIds())
        {
            GameDataButton find = gameDataButtons.First(gameDataButton => gameDataButton.GameDataId == gameDataId);
            find.Behaviour = GameDataButtonBehaviour.LOAD;
        }
    }
}
