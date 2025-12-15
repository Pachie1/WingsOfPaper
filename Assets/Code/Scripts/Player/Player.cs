using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] public string Enemytag;
    [SerializeField] public int HitPoints;
    [SerializeField] public int maxHitPoints;

    public bool isInvincible = false;

    [Header("Menu")]
    [SerializeField] private GameObject menuManager;

    private Animator animator;
    private PlayerAudio playerAudio;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<PlayerAudio>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Enemytag)) return;

        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet == null) return;

        Destroy(other.gameObject);
        TakeDamage(bullet.damage);
    }
    private void TakeDamage(int damage)
    {
        if (isInvincible) return;
        if (damage <= 0) return;

        if (animator != null) animator.SetTrigger("OnHit");
        if (playerAudio != null) playerAudio.PlayHit();

        HitPoints -= damage;

        if (HitPoints <= 0)
        {
            HitPoints = 0;
            Die();
        }
    }
    private void Die()
    {
        if (animator != null) animator.SetTrigger("Dead");
        if (playerAudio != null) playerAudio.PlayDeath();

        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null) Destroy(col);

        if (menuManager != null)
        {
            MenuManager mm = menuManager.GetComponent<MenuManager>();
            if (mm != null) mm.OpenResetMenu();
        }
    }
    private void OnDeadAnimation()
    {
        Destroy(gameObject, 0f);
    }
    public bool TryHeal(int amount)
    {
        if (amount <= 0) return false;
        if (HitPoints <= 0) return false;
        if (HitPoints >= maxHitPoints) return false;

        HitPoints = Mathf.Min(HitPoints + amount, maxHitPoints);
        return true;
    }
}