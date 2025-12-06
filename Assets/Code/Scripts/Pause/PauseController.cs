using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
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

        Debug.Log("currentGameState: " + currentGameState);
        GameState newGameState;

        if (currentGameState == GameState.Gameplay) 
        {
            newGameState = GameState.Pause;
        }else
        {
            newGameState = GameState.Gameplay;
        }
        GameStateManager.Instance.SetState(newGameState);
        Debug.Log("newGameState: " + newGameState);
    }
}
