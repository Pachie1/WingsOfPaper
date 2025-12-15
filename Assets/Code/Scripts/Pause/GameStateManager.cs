using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance; //-------------Check why does this HAVE to be static-------------

    public static GameStateManager Instance //-------------Check why does this HAVE to be static-------------
    {
        get
        {

            GameObject GameStateManagersAlive = GameObject.FindGameObjectWithTag("GameStateManagerTag");
            if (GameStateManagersAlive == null)
            {
                GameObject gameStateObject = new GameObject("GameStateManager");
                _instance = gameStateObject.AddComponent<GameStateManager>();
                _instance.gameObject.tag = "GameStateManagerTag";
            }
            return _instance;
        }
    }

    public GameState CurrentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
        {
            return;
        }
        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState); 
    }
}
