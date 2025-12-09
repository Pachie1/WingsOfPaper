using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Level level;

    [Header("Player")]
    [SerializeField] private GameObject Player;
    [SerializeField] private string playerTag = "Player";

    [Header("Reset canvas")]
    [SerializeField] private GameObject ResetCanvas;


    private void Start()
    {
        levelManager.LoadLevel(level);
    }

    public void LoadScene(Level level) 
    {
        levelManager.LoadLevel(level);
    }

    void Update()
    {
        if (!Player)
        {
            Debug.Log("No esta el player");
            ResetCanvas.SetActive(true);
        }
    }
}

