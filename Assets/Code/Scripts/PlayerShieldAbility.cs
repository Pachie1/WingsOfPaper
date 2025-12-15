using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShieldAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private InputActionReference shieldAction;

    [Header("Shield Settings")]
    [SerializeField] private float invincibleSeconds = 1f;
    [SerializeField] private float cooldownSeconds = 12f;

    [Header("UI")]
    [SerializeField] private Image shieldIcon;
    [SerializeField] private Sprite availableSprite;
    [SerializeField] private Sprite cooldownSprite;

    private float cooldownRemaining;
    private float invincibleRemaining;
    private bool shieldActive;

    private void Awake()
    {
        if (player == null) player = GetComponent<Player>();
    }
    private void OnEnable()
    {
        if (shieldAction != null)
        {
            shieldAction.action.performed += OnShieldPerformed;
            shieldAction.action.Enable();
        }

        RefreshIcon();
    }
    private void OnDisable()
    {
        if (shieldAction != null)
        {
            shieldAction.action.performed -= OnShieldPerformed;
            shieldAction.action.Disable();
        }
    }
    private void Update()
    {
        if (cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining < 0f) cooldownRemaining = 0f;
        }

        if (shieldActive)
        {
            invincibleRemaining -= Time.deltaTime;
            if (invincibleRemaining <= 0f)
            {
                invincibleRemaining = 0f;
                shieldActive = false;
                if (player != null) player.isInvincible = false;
            }
        }

        RefreshIcon();
    }
    private void OnShieldPerformed(InputAction.CallbackContext ctx)
    {
        if (player == null) return;
        if (cooldownRemaining > 0f) return;
        if (player.HitPoints <= 0) return;

        shieldActive = true;
        invincibleRemaining = invincibleSeconds;
        player.isInvincible = true;

        cooldownRemaining = cooldownSeconds;

        RefreshIcon();
    }
    private void RefreshIcon()
    {
        if (shieldIcon == null) return;

        bool available = cooldownRemaining <= 0f;

        if (available && availableSprite != null)
            shieldIcon.sprite = availableSprite;
        else if (!available && cooldownSprite != null)
            shieldIcon.sprite = cooldownSprite;
    }
}