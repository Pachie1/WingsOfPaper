using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private GameObject pauseCanvas;

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    void OnEnable()
    {
        pauseAction.action.started += HandlePauseInput;
    }

    void OnDisable()
    {
        pauseAction.action.started -= HandlePauseInput;
    }

    private void HandlePauseInput(InputAction.CallbackContext context)
    {
        Debug.Log("Pause");
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        TriggerGameState(currentGameState);
    }

    public void ChangeGameState() 
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        TriggerGameState(currentGameState);
    }

    private void TriggerGameState(GameState currentGameState) 
    {
        Debug.Log("currentGameState: " + currentGameState);
        GameState newGameState;

        if (currentGameState == GameState.Gameplay)
        {
            newGameState = GameState.Pause;
            pauseCanvas.SetActive(true);
        }
        else
        {
            newGameState = GameState.Gameplay;
            pauseCanvas.SetActive(false);
        }
        GameStateManager.Instance.SetState(newGameState);
        Debug.Log("newGameState: " + newGameState);
    }
}
