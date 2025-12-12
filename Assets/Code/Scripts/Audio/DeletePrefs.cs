using UnityEngine;

public class DeletePrefs : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Todas las PlayerPrefs han sido borradas. Reinicie el juego.");
    }
}