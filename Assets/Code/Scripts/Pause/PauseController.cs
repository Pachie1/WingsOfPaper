using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{

    [Header("Actions")]
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private InputActionReference cheatAction;

    [SerializeField] private GameObject gameManager;
    [SerializeField] private Level level;

    private GameManager gameManagerComp;
    public bool pauseInput = false;
    public bool cheatInput = false;
    void OnEnable()
    {
        if (cheatAction != null && cheatAction.action != null)
        {
            cheatAction.action.started += HandleCheatAction;
        }

        if (pauseAction != null && pauseAction.action != null)
        {
            pauseAction.action.started += HandlePauseInput;
        }
    }

    void OnDisable()
    {
        if (cheatAction != null && cheatAction.action != null)
        {
            cheatAction.action.started -= HandleCheatAction;
        }

        if (pauseAction != null && pauseAction.action != null)
        {
            pauseAction.action.started -= HandlePauseInput;

        }
    }
    private void HandleCheatAction(InputAction.CallbackContext context)
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        cheatInput = true;
        pauseInput = false;
        TriggerGameState(currentGameState);

    }

    private void HandlePauseInput(InputAction.CallbackContext context)
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        cheatInput = false;
        pauseInput = true;
        TriggerGameState(currentGameState);
    }

    public void ChangeGameState()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        TriggerGameState(currentGameState);
    }

    private void TriggerGameState(GameState currentGameState)
    {
        Debug.Log("inicio currentGameState: " + currentGameState);
        GameState newGameState;

        if (currentGameState == GameState.Gameplay)
        {
            newGameState = GameState.Pause;
            GameStateManager.Instance.SetState(newGameState);

            gameManagerComp = gameManager.GetComponent<GameManager>();
            gameManagerComp.LoadSceneAdditive(level);
        }
        else
        {
            newGameState = GameState.Gameplay;
            GameStateManager.Instance.SetState(newGameState);
            gameManagerComp.UnLoadScene(level); 
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
