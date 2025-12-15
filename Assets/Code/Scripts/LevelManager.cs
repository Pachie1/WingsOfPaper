using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class LevelManager : MonoBehaviour
{
    private Scene lastScene = default;

    public void LoadLevel(Level level)
    {
        foreach (string sceneName in level.scenes)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public IEnumerator LoadLevelAdditive(Level level)
    {
        foreach (string sceneName in level.scenes)
        {
            AsyncOperation load = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return load;

            lastScene = SceneManager.GetSceneByName(sceneName);
        }

        SceneManager.SetActiveScene(lastScene);
    }

    public void UnLoadLevel(Level level)
    {
        foreach (string scene in level.scenes)
        {
            SceneManager.UnloadSceneAsync(scene);
        }

    }
}

