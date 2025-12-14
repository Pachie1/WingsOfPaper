using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using static UnityEditor.Rendering.FilterWindow;
using UnityEditor;
using JetBrains.Rider.Unity.Editor;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private GameObject menuManagerObj;

    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject videoMenu;
    [SerializeField] private GameObject controlMenu;

    [Header("Higjlighted")]
    [SerializeField] private GameObject pauseMenuHighlighted;
    [SerializeField] private GameObject audioMenuHighlighted;
    [SerializeField] private GameObject videoMenuHighlighted;
    [SerializeField] private GameObject controlMenuHighlighted;



    private MenuManager menuManager;
    private GameObject currentMenu;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    void OnEnable()
    {
        if (pauseAction != null && pauseAction.action != null)
        {
            pauseAction.action.started += HandlePauseInput;
        }
    }

    void OnDisable()
    {
        if (pauseAction != null && pauseAction.action != null)
        {
            pauseAction.action.started -= HandlePauseInput;
        }
    }

    private void HandlePauseInput(InputAction.CallbackContext context)
    {
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
        Debug.Log("inicio currentGameState: " + currentGameState);
        GameState newGameState;

        if (currentGameState == GameState.Gameplay)
        {
            newGameState = GameState.Pause;
            pauseMenu.SetActive(true);
            GameStateManager.Instance.SetState(newGameState);
        }
        else
        {
            menuManager = menuManagerObj.GetComponent<MenuManager>();
            currentMenu = menuManager.currentMenu;

            Debug.Log("currentMenu: " + currentMenu);
            //If its not in the pauseMenu and neither in the optionsMenu. it means that its in audio/video/controls so it must go back to the options menu
            if (currentMenu != pauseMenu && currentMenu != optionsMenu)
            {
                Debug.Log("backToOptionsMenu");
                if (currentMenu == audioMenu) 
                {
                    HighLightElement(audioMenuHighlighted);
                }

                if (currentMenu == videoMenu)
                {
                    HighLightElement(videoMenuHighlighted);
                }

                if (currentMenu == controlMenu)
                {
                    HighLightElement(controlMenuHighlighted);
                }
                menuManager.BackToOptionsMenu();
                menuManager.currentMenu = optionsMenu;
            }
            else
            {
                //If its not in the pauseMenu. It means that its in options menu so it must go back to the pause menu
                if (currentMenu != pauseMenu) 
                {
                    Debug.Log("closeOptionsMenu");
                    menuManager.CloseOptionsMenu();
                    menuManager.currentMenu = pauseMenu;
                    HighLightElement(pauseMenuHighlighted);
                }
                else
                {
                    newGameState = GameState.Gameplay;
                    pauseMenu.SetActive(false);
                    GameStateManager.Instance.SetState(newGameState);
                    Debug.Log("newGameState: " + newGameState);
                }
            }
        }
    }


    public void HighLightElement(GameObject element) 
    {
        EventSystem.current.SetSelectedGameObject(element);
    }
}
