using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayClick()
    {
        if (AudioManager.Instance == null) return;

        AudioManager.Instance.PlayDefaultClick();
    }
}