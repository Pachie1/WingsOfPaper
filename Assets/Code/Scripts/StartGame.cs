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
  
    }
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