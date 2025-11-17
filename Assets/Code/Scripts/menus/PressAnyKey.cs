using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 
public class PressAnyKey: MonoBehaviour
{
    [SerializeField] private InputActionReference action;


    private void Update()
    {
        if (action.action.IsPressed())
        {
           
        }
    }
}
