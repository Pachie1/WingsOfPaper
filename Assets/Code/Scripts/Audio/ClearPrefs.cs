using UnityEngine;
public class ClearPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs borrados. ¡Reinicia el juego!");
    }
}