using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip hoverClip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOVER UI en: " + gameObject.name);

        if (audioManager == null)
        {
            Debug.LogError("AudioManager NO asignado en " + gameObject.name);
            return;
        }

        if (hoverClip == null)
        {
            Debug.LogError("hoverClip NO asignado en " + gameObject.name);
            return;
        }

        audioManager.PlayUISound(hoverClip);
    }
}