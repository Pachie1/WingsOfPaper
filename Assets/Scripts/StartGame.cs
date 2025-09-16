using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;
    private InputAction anyKey;

    private void Awake()
    {
        Time.timeScale = 0f;
        anyKey = new InputAction(type: InputActionType.Button, binding: "/*/<Button>");
        anyKey.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (anyKey.triggered)
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }
    }
}
