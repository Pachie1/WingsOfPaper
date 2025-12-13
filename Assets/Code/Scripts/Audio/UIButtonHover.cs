using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (AudioManager.Instance == null) return;

        AudioManager.Instance.PlayDefaultHover();
    }
}