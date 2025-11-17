using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Level level;

    private void Start()
    {
        levelManager.LoadLevel(level);
    }

    public void LoadScene(Level level) 
    {
        levelManager.LoadLevel(level);
    }

}

