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
    private bool resetHightlightedFlag = false;

    private void Awake()
    {
        globalLight2D = GameObject.FindGameObjectWithTag("GlobalLight");
        light = globalLight2D.GetComponent<Light2D>();
        DontDestroyOnLoad(globalLight2D);
    }
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pauseControllerComp = gameManager.GetComponent<PauseController>();
        gameManagerComp = gameManager.GetComponent<GameManager>();


        if (mainMenu != null)
        {
            HighLightElement(mainMenuHighlighted); 
        }
        if (pauseMenu != null)
        {
            if (pauseControllerComp.pauseInput == true)
            {
                pauseMenu.SetActive(true);
                if (pauseMenuHighlighted != null)
                {
                    HighLightElement(pauseMenuHighlighted);
                }
                pauseControllerComp.pauseInput = false;
            }
            
            if(pauseControllerComp.cheatInput == true)
            {
                if (cheatMenu != null)
                {
                    cheatMenu.SetActive(true); 
                }
                pauseMenu.SetActive(false);
                if (cheatMenuHighlighted != null)
                {
                    HighLightElement(cheatMenuHighlighted);
                }
                pauseControllerComp.cheatInput = false;
            }
        }
        
        brightnessSlider.GetComponent<Slider>().value = light.intensity;
    }

    private void Update()
    {   
        light.intensity = brightnessSlider.GetComponent<Slider>().value;
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(false);
            }
            if (resetMenu != null)
            {
                resetMenu.SetActive(true);
            }
            if (resetMenuHightlighted != null && resetHightlightedFlag == false)
            {
                HighLightElement(resetMenuHightlighted);
                resetHightlightedFlag = true;
            }
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
        pauseControllerComp.ChangeGameState();
    }

    public void ResetGameplay()
    {
        Debug.Log("RESET");
        gameManagerComp.UnLoadScene(Gameplay);
        gameManagerComp.UnLoadScene(Pause);
        gameManagerComp.LoadScene(Gameplay);
    }

    public void BachToMenu()
    {
        gameManagerComp.LoadScene(Menu);
    }
}
