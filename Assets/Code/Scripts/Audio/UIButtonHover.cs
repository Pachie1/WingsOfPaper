using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip hoverClip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioManager == null || hoverClip == null) return;
        audioManager.PlayUISound(hoverClip);
    }
}