using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject videoMenu;
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject cheatMenu;
    [SerializeField] public GameObject currentMenu;

    [Header("Highlighted")]
    [SerializeField] private GameObject mainMenuHighlighted;
    [SerializeField] private GameObject pauseMenuHighlighted;
    [SerializeField] private GameObject audioMenuHighlighted;
    [SerializeField] private GameObject videoMenuHighlighted;
    [SerializeField] private GameObject controlMenuHighlighted;
    [SerializeField] private GameObject resetMenuHightlighted;
    [SerializeField] private GameObject cheatMenuHighlighted;

    [Header("Light")]
    [SerializeField] private GameObject brightnessSlider;
    private GameObject globalLight2D;
    private Light2D light;

    [Header("Actions")]
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private InputActionReference cheatAction;

    [Header("Scenes")]
    [SerializeField] private Level Pause;
    [SerializeField] private Level Gameplay;
    [SerializeField] private Level Menu;

    private GameObject gameManager;
    private GameManager gameManagerComp;
    private PauseController pauseControllerComp;
    private GameObject player;
    private bool cheatInput = false;
    private bool pauseInput = false;
    /*
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
                    pauseMenu.SetActive(false);
                    cheatMenu.SetActive(false);
                }
            }
        }
    }
    */
    private void Awake()
    {
        globalLight2D = GameObject.FindGameObjectWithTag("GlobalLight");
        light = globalLight2D.GetComponent<Light2D>();
        DontDestroyOnLoad(globalLight2D);
    }
    private void Start()
    {
        if (mainMenu != null)
        {
            HighLightElement(mainMenuHighlighted); 
        }
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            HighLightElement(pauseMenuHighlighted);
        }
        
        brightnessSlider.GetComponent<Slider>().value = light.intensity;
    }

    private void Update()
    {   
        light.intensity = brightnessSlider.GetComponent<Slider>().value;
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            pauseMenu.SetActive(false);
            resetMenu.SetActive(true);
            HighLightElement(resetMenuHightlighted);
        }
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
        currentMenu = menu;
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

    public void Unpause() 
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pauseControllerComp = gameManager.GetComponent<PauseController>();
        pauseControllerComp.ChangeGameState();
    }

    public void ResetGameplay()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerComp = gameManager.GetComponent<GameManager>();
        gameManagerComp.UnLoadSceneAndLoadScene(Pause, Gameplay);
    }

    public void BachToMenu()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerComp = gameManager.GetComponent<GameManager>();
        gameManagerComp.LoadScene(Menu);
    }
}
