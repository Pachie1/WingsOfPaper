using UnityEngine;
using UnityEngine.InputSystem;

public class CheatManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private EnemyManager enemyManager;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference invincibleAction;
    [SerializeField] private InputActionReference speedAction;
    [SerializeField] private InputActionReference killAllAction;
    [SerializeField] private InputActionReference fireRateAction;
    [SerializeField] private InputActionReference healAction;

    [Header("Cheat Settings")]
    [SerializeField] private float speedMultiplier = 3f;
    [SerializeField] private float fireRateDivisor = 3f;

    private bool invincibleToggle;
    private bool speedToggle;
    private bool fireRateToggle;

    private float defaultSpeed;
    private float defaultFiringRate;
    private void OnEnable()
    {
        if (invincibleAction != null) invincibleAction.action.performed += OnInvincible;
        if (speedAction != null) speedAction.action.performed += OnSpeed;
        if (killAllAction != null) killAllAction.action.performed += OnKillAll;
        if (fireRateAction != null) fireRateAction.action.performed += OnFireRate;
        if (healAction != null) healAction.action.performed += OnHeal;

        EnableActions(true);
    }
    private void OnDisable()
    {
        if (invincibleAction != null) invincibleAction.action.performed -= OnInvincible;
        if (speedAction != null) speedAction.action.performed -= OnSpeed;
        if (killAllAction != null) killAllAction.action.performed -= OnKillAll;
        if (fireRateAction != null) fireRateAction.action.performed -= OnFireRate;
        if (healAction != null) healAction.action.performed -= OnHeal;

        EnableActions(false);
    }
    private void Start()
    {
        CacheDefaults();
    }
    private void EnableActions(bool enable)
    {
        if (invincibleAction != null) SetAction(invincibleAction, enable);
        if (speedAction != null) SetAction(speedAction, enable);
        if (killAllAction != null) SetAction(killAllAction, enable);
        if (fireRateAction != null) SetAction(fireRateAction, enable);
        if (healAction != null) SetAction(healAction, enable);
    }
    private void SetAction(InputActionReference actionRef, bool enable)
    {
        if (enable) actionRef.action.Enable();
        else actionRef.action.Disable();
    }
    private void CacheDefaults()
    {
        if (inputReader == null) return;

        defaultSpeed = inputReader.GetDefaultSpeed();
        defaultFiringRate = inputReader.GetDefaultFiringRate();
    }
    private void OnInvincible(InputAction.CallbackContext _)
    {
        if (player == null) return;

        invincibleToggle = !invincibleToggle;
        player.isInvincible = invincibleToggle;
    }
    private void OnSpeed(InputAction.CallbackContext _)
    {
        if (inputReader == null) return;

        if (!speedToggle && defaultSpeed <= 0f)
            CacheDefaults();

        speedToggle = !speedToggle;

        float newSpeed = speedToggle
            ? defaultSpeed * speedMultiplier
            : defaultSpeed;

        inputReader.SetCurrentSpeed(newSpeed);
    }
    private void OnKillAll(InputAction.CallbackContext _)
    {
        if (enemyManager == null) return;

        enemyManager.ForceNextWave();
    }
    private void OnFireRate(InputAction.CallbackContext _)
    {
        if (inputReader == null) return;

        if (!fireRateToggle && defaultFiringRate <= 0f)
            CacheDefaults();

        fireRateToggle = !fireRateToggle;

        float newRate = fireRateToggle
            ? defaultFiringRate / fireRateDivisor
            : defaultFiringRate;

        inputReader.SetCurrentFiringRate(newRate);
    }
    private void OnHeal(InputAction.CallbackContext _)
    {
        if (player == null) return;

        player.HitPoints = player.maxHitPoints;
    }
}