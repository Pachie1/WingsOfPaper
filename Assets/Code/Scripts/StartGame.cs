using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField] private InputActionReference enterAction;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //if (anyKey.triggered)
        if (enterAction.action.IsPressed())
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }
    }
}
