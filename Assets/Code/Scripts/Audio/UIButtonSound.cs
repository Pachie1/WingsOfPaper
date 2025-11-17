using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip clickClip;

    public void PlayClick()
    {
        audioManager.PlayUISound(clickClip);
    }
}