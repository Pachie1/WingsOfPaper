using UnityEngine;

public class MenuManagerActive : MonoBehaviour
{
    [SerializeField] private GameObject menuManager;
    private MenuManager menuManagerComp;
    void Start()
    {
        menuManagerComp = menuManager.GetComponent<MenuManager>();
        menuManagerComp.enabled= true;
    }
}
