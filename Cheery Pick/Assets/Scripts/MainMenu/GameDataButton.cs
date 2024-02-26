using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameDataButtonBehaviour
{
    NEW_GAME,
    LOAD
}

[RequireComponent(typeof(Button))]
public class GameDataButton : MonoBehaviour
{
    public int GameDataId;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private GameDataButtonBehaviour _behaviour;
    public GameDataButtonBehaviour Behaviour
    {
        get { return _behaviour; }
        set
        {
            _behaviour = value;
            _buttonText.text = _behaviour == GameDataButtonBehaviour.NEW_GAME ? "New game" : $"Load game {GameDataId}";
        }
    }

    private void Start()
    {
        Behaviour = GameDataButtonBehaviour.NEW_GAME;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        GameLoader gameLoader = FindObjectOfType<GameLoader>();
        switch (_behaviour)
        {
            case GameDataButtonBehaviour.NEW_GAME:
                gameLoader.StartNewGame();
                break;

            case GameDataButtonBehaviour.LOAD:
                gameLoader.LoadGame(GameDataId);
                break;
        }
    }
}
