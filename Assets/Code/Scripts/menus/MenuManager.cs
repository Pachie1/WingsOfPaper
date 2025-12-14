using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    private PauseController pauseController;

    [Header("Menus")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject resetMenuHightlighted;
    [SerializeField] public GameObject currentMenu;

    [Header("Light")]
    [SerializeField] private GameObject globalLight2D;
    [SerializeField] private GameObject brightnessSlider;
    private Light2D light;

    private void Awake()
    {
        light = globalLight2D.GetComponent<Light2D>();
    }
    private void Start()
    {
        Debug.Log("currentMenu: " + currentMenu);
        brightnessSlider.GetComponent<Slider>().value = light.intensity;
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
