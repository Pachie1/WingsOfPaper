using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioManager audioManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioManager == null) return;
        audioManager.PlayDefaultHover();
    }
}