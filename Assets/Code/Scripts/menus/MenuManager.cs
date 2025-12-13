using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    private PauseController pauseController;

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] public GameObject currentMenu;

    private void Start()
    {
        Debug.Log("currentMenu: " + currentMenu);
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

    public void Unpause()
    {
        pauseController = GameManager.GetComponent<PauseController>();
        pauseController.ChangeGameState();
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
}
