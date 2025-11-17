using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Level level;

    public void PlayGame() 
    {
        gameManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
