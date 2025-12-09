using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    [Header("Buttons")]
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonReset;
    [SerializeField] private Button buttonExit;

    [Header("Exit Event")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Level level;

    private PauseController pauseController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonResume.onClick.AddListener(ResumeScene);
        buttonReset.onClick.AddListener(ResetScene);
        buttonExit.onClick.AddListener(ExitScene);
    }

    void ResumeScene()
    {
        pauseMenu.SetActive(false);
        pauseController = gameManager.GetComponent<PauseController>();
        pauseController.ChangeGameState();
    }
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitScene()
    {
        gameManager.LoadScene(level);
    }
}
