using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PressAnyKey : MonoBehaviour
{
    [SerializeField] private InputActionReference startAction;
    [SerializeField] private GameObject MainMenu;

    void OnEnable()
    {
        if (startAction != null && startAction.action != null)
        {
            startAction.action.Enable();
        }
    }
    void OnDisable()
    {
        if (startAction != null && startAction.action != null)
        {
            startAction.action.Disable();
        }
    }
    void Update()
    {
        if (startAction != null && startAction.action != null && startAction.action.WasPressedThisFrame())
        {
            StartGame();
        }
    }
    void StartGame()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
        enabled = false;
    }
}