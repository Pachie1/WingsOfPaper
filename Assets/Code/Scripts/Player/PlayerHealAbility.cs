using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerAudio playerAudio;
    [SerializeField] private InputActionReference healAction;

    [Header("Heal Settings")]
    [SerializeField] private int healAmount = 1;
    [SerializeField] private float cooldownSeconds = 12f;

    [Header("UI")]
    [SerializeField] private Image healIcon;
    [SerializeField] private Sprite availableSprite;
    [SerializeField] private Sprite cooldownSprite;

    private float cooldownRemaining;
    private void Awake()
    {
        if (player == null) player = GetComponent<Player>();
        if (playerAudio == null) playerAudio = GetComponent<PlayerAudio>();
    }
    private void OnEnable()
    {
        if (healAction == null) return;

        healAction.action.performed += OnHealPerformed;
        healAction.action.Enable();
        UpdateIcon();
    }
    private void OnDisable()
    {
        if (healAction == null) return;

        healAction.action.performed -= OnHealPerformed;
        healAction.action.Disable();
    }
    private void Update()
    {
        if (cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining <= 0f)
            {
                cooldownRemaining = 0f;
                UpdateIcon();
            }
        }
    }
    private void OnHealPerformed(InputAction.CallbackContext ctx)
    {
        if (cooldownRemaining > 0f) return;
        if (player == null) return;

        bool healed = player.TryHeal(healAmount);
        if (!healed) return;

        if (playerAudio != null)
            playerAudio.PlayHeal();

        cooldownRemaining = cooldownSeconds;
        UpdateIcon();
    }
    private void UpdateIcon()
    {
        if (healIcon == null) return;

        if (cooldownRemaining > 0f)
            healIcon.sprite = cooldownSprite;
        else
            healIcon.sprite = availableSprite;
    }
}