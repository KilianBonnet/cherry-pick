using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(LocalizeStringEvent))]
public class GameLauncherButton : MonoBehaviour
{
    [SerializeField] private int _gameDataId;
    private bool _hasSavedGameDataId;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);

        _hasSavedGameDataId = FindObjectOfType<FileManager>().HasSavedGameDataId(_gameDataId);
        LocalizeStringEvent localizeString = GetComponent<LocalizeStringEvent>();

        localizeString.StringReference = new(
            "MainMenuScene",
            _hasSavedGameDataId ? "load-game-button" : "new-game-button"
        );
    }

    private void OnButtonClick()
    {
        GameLoader gameLoader = FindObjectOfType<GameLoader>();

        if (_hasSavedGameDataId)
            gameLoader.LoadGame(_gameDataId);
        else
            gameLoader.StartNewGame();
    }
}
