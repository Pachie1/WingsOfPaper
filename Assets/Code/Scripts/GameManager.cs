using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Level mainMenu;

    private void Start()
    {
        levelManager.LoadLevel(mainMenu);
    }

}

