using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Level level;

    [Header("LevelFailed")]
    [SerializeField] private Level levelFailed;
    private bool resetMenuLoad = false;

    [Header("Player")]
    [SerializeField] private GameObject Player;

    private void Start()
    {
        levelManager.LoadLevel(level);
    }

    private void Update()
    {
        if (!Player && resetMenuLoad == false)
        {
            LoadSceneAdditive(levelFailed);
            resetMenuLoad = true;
        }
    }

    public void LoadScene(Level level)
    {
        levelManager.LoadLevel(level);
    }

    public void LoadSceneAdditive(Level level) 
    {
        StartCoroutine(levelManager.LoadLevelAdditive(level));
    }

    public void UnLoadScene(Level level)
    {
        levelManager.UnLoadLevel(level);
    }

    public void UnLoadSceneAndLoadScene(Level levelUnload,Level levelLoad)
    {
        levelManager.UnLoadLevel(levelUnload);

        levelManager.LoadLevel(level);
    }
}

