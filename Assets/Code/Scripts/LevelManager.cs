using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(Level level)
    {
        foreach(string scene in level.scenes)
        {
            SceneManager.LoadScene(scene);
        }
        
    }

    public void UnLoadLevel(Level level)
    {
        foreach (string scene in level.scenes)
        {
            SceneManager.UnloadSceneAsync(scene);
        }

    }
}

