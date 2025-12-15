using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.InputSystem.Controls;

public class PressAnyKey : MonoBehaviour
{
    [SerializeField] private InputActionReference startAction;
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private GameObject MenuManager;
    [SerializeField] private GameObject MainMenuHighLightedElement;

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
        if (startAction != null) 
        {
            Debug.Log("startAction != null: " + true);
        }
        else
        {
            Debug.Log("startAction != null: " + false);
        }

        if (startAction.action != null)
        {
            Debug.Log("startAction.action != null: " + true);
        }
        else
        {
            Debug.Log("startAction.action != null: " + false);
        }

        if (startAction.action.WasPressedThisFrame())
        {
            Debug.Log("startAction != null: " + true);
        }
        else
        {
            Debug.Log("startAction != null: " + false);
        }

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

        MenuManager.GetComponent<MenuManager>().HighLightElement(MainMenuHighLightedElement);
    }
}