using UnityEngine;

public class MenuManagerActive : MonoBehaviour
{
    [SerializeField] private GameObject menuManager;
    private MenuManager menuManagerComp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuManagerComp = menuManager.GetComponent<MenuManager>();
        menuManagerComp.enabled= true;
    }
}
