using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button buttonReset;
    [SerializeField] private GameObject Player;
    [SerializeField] private string playerTag = "Player";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonReset.onClick.AddListener(ResetScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player) 
        {
            buttonReset.gameObject.SetActive(true);
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
