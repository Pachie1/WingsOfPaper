using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Level level;

    public void Start()
    {
        Debug.Log("INICIO");
    }
    public void PlayGame() 
    {
        Debug.Log("Click");
        gameManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
