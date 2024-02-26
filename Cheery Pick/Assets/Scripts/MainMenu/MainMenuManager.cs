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
        SaveManager saveManager = FindAnyObjectByType<SaveManager>();
        GameDataButton[] gameDataButtons = FindObjectsOfType<GameDataButton>();

        foreach (int gameDataId in saveManager.GetSavedGameDataIds())
        {
            GameDataButton find = gameDataButtons.First(gameDataButton => gameDataButton.GameDataId == gameDataId);
            find.Behaviour = GameDataButtonBehaviour.LOAD;
        }
    }
}
