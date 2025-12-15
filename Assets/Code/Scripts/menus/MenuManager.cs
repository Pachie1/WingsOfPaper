using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;

    [Header("Menus")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject videoMenu;
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject cheatMenu;
    [SerializeField] public GameObject currentMenu;

    [Header("Highlighted")]
    [SerializeField] private GameObject resetMenuHightlighted;
    [SerializeField] private GameObject pauseMenuHighlighted;
    [SerializeField] private GameObject audioMenuHighlighted;
    [SerializeField] private GameObject videoMenuHighlighted;
    [SerializeField] private GameObject controlMenuHighlighted;
    [SerializeField] private GameObject cheatMenuHighlighted;

    [Header("Light")]
    [SerializeField] private GameObject globalLight2D;
    [SerializeField] private GameObject brightnessSlider;
    private Light2D light;

    [Header("Actions")]
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private InputActionReference cheatAction;

    private bool cheatInput = false;
    private bool pauseInput = false;
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
        currentMenu = cheatMenu;
        TriggerGameState(currentGameState);

    }

    private void HandlePauseInput(InputAction.CallbackContext context)
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
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
            if (pauseInput == true) 
            {
                pauseMenu.SetActive(true);
                HighLightElement(pauseMenuHighlighted);

                cheatMenu.SetActive(false);
                
                pauseInput = false;
            }
            
            if (cheatInput == true)
            {
                pauseMenu.SetActive(false);

                cheatMenu.SetActive(true);
                HighLightElement(cheatMenuHighlighted);
                
                cheatInput = false;
            } 
            
            GameStateManager.Instance.SetState(newGameState);
        }
        else
        {
            Debug.Log("currentMenu: " + currentMenu);
            //If its not in the pauseMenu and neither in the optionsMenu. it means that its in audio/video/controls so it must go back to the options menu
            if (currentMenu != pauseMenu && currentMenu != optionsMenu && currentMenu != cheatMenu)
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
                BackToOptionsMenu();
                currentMenu = optionsMenu;
            }
            else
            {
                //If its not in the pauseMenu. It means that its in options menu so it must go back to the pause menu
                if (currentMenu != pauseMenu && currentMenu != cheatMenu)
                {
                    Debug.Log("closeOptionsMenu");
                    CloseOptionsMenu();
                    currentMenu = pauseMenu;
                    HighLightElement(pauseMenuHighlighted);
                }
                else
                {
                    newGameState = GameState.Gameplay;
                    pauseMenu.SetActive(false);
                    cheatMenu.SetActive(false);
                    GameStateManager.Instance.SetState(newGameState);
                    Debug.Log("newGameState: " + newGameState);
                }
            }
        }
    }

    private void Awake()
    {
        light = globalLight2D.GetComponent<Light2D>();
    }
    private void Start()
    {
        Debug.Log("currentMenu: " + currentMenu);
        brightnessSlider.GetComponent<Slider>().value = light.intensity;


        pauseMenu.SetActive(false);
    }

    private void Update()
    {   
        light.intensity = brightnessSlider.GetComponent<Slider>().value;
    }

    public void ToggleFullScreen() 
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else 
        {
            Screen.fullScreen = true;
        }
    }

    public void CloseOptionsMenu()
    {
        Debug.Log("CloseOptionsMenu"); 
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void BackToOptionsMenu() 
    {
        currentMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void SetCurrentMenu(GameObject menu) 
    {
        currentMenu= menu;
        Debug.Log("currentMenu: " + currentMenu);
    }

    public void OpenResetMenu()
    {
        resetMenu.SetActive(true);
        HighLightElement(resetMenuHightlighted);
    }

    public void HighLightElement(GameObject element)
    {
        EventSystem.current.SetSelectedGameObject(element);
    }
}
