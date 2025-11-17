using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button buttonReset;
    [SerializeField] private Button buttonExit;

    [Header("Player")]
    [SerializeField] private GameObject Player;
    [SerializeField] private string playerTag = "Player";

    [Header("Exit Event")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Level level;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonReset.onClick.AddListener(ResetScene);
        buttonExit.onClick.AddListener(ExitScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player) 
        {
            buttonReset.gameObject.SetActive(true);
            buttonExit.gameObject.SetActive(true);
        }
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
