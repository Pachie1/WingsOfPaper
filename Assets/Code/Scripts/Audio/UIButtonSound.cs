using UnityEngine;
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlayClick()
    {
        if (audioManager == null) return;
        audioManager.PlayDefaultClick();
    }
}