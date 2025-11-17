using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 
public class PressAnyKey: MonoBehaviour
{
    [SerializeField] private InputActionReference action;
    [SerializeField] private GameObject MainMenu;

    private void Update()
    {
        if (action.action.IsPressed())
        {
            Debug.Log("AnyKey");
            MainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
