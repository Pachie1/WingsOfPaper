using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatManager : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Player player;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private EnemyManager enemyManager;

    [Header("Cheat Settings")]
    [SerializeField] private float speedMultiplier = 3f;
    [SerializeField] private float fireRateDivisor = 3f;

    private bool invincibleToggle = false;
    private bool speedToggle = false;
    private bool fireRateToggle = false;

    private float defaultSpeed = 0f;
    private float defaultFiringRate = 0f;

    void Start()
    {
        if (inputReader != null)
        {
            defaultSpeed = inputReader.GetDefaultSpeed();
            defaultFiringRate = inputReader.GetDefaultFiringRate();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ToggleInvincible();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            ToggleSpeed();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            KillAllEnemies();
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            ToggleFireRate();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            HealPlayer();
        }
    }

    private void ToggleInvincible()
    {
        invincibleToggle = !invincibleToggle;

        if (player != null)
        {
            player.isInvincible = invincibleToggle;
            Debug.Log("Cheat: Invincibility " + (invincibleToggle ? "ACTIVATED (F2)" : "DEACTIVATED (F2)"));
        }
    }

    private void ToggleSpeed()
    {
        speedToggle = !speedToggle;

        if (inputReader == null)
        {
            Debug.LogError("InputReader reference missing.");
            return;
        }

        if (speedToggle)
        {
            inputReader.SetCurrentSpeed(defaultSpeed * speedMultiplier);
        }
        else
        {
            inputReader.SetCurrentSpeed(defaultSpeed);
        }
        Debug.Log("Cheat: Speed " + (speedToggle ? "ACTIVATED (F3)" : "DEACTIVATED (F3)"));
    }

    private void KillAllEnemies()
    {
        if (enemyManager != null)
        {
            enemyManager.ForceNextWave();
            Debug.Log("Cheat: Kill All Enemies (F4) executed. Starting next wave.");
        }
        else
        {
            Debug.LogError("EnemyManager reference missing. Cannot kill all enemies.");
        }
    }

    private void ToggleFireRate()
    {
        fireRateToggle = !fireRateToggle;

        if (inputReader == null)
        {
            Debug.LogError("InputReader reference missing.");
            return;
        }

        float newRate;
        if (fireRateToggle)
        {
            newRate = defaultFiringRate / fireRateDivisor;
        }
        else
        {
            newRate = defaultFiringRate;
        }

        inputReader.SetCurrentFiringRate(newRate);

        Debug.Log("Cheat: Fire Rate Boost " + (fireRateToggle ? "ACTIVATED x" + fireRateDivisor + " (F5)" : "DEACTIVATED x1 (F5)"));
    }

    private void HealPlayer()
    {
        if (player != null)
        {
            player.HitPoints = player.maxHitPoints;
            Debug.Log("Cheat: Health restored to max (" + player.HitPoints + ") (F6).");
        }
        else
        {
            Debug.LogError("Player is not assigned. Cannot heal player.");
        }
    }
}