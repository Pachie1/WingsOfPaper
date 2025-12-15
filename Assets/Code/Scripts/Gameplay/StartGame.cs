using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField] private InputActionReference enterAction;
    private void Awake()
    {

    }
    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (enterAction.action.IsPressed())
        {
            Debug.Log("Action Pressed");
            Time.timeScale = 1f;
            canvas.SetActive(false);
        } 
    }
}