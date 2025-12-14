using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    private Animator animator;
    [SerializeField] public string Enemytag;
    [SerializeField] public int HitPoints;
    [SerializeField] public int maxHitPoints;

    public bool isInvincible = false;
    [Header("Audio")]
    private PlayerAudio playerAudio;

    [Header("Menu")]
    [SerializeField] private GameObject menuManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<PlayerAudio>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Enemytag))
        {
            Bullet bullet = other.GetComponent<Bullet>();

            if (bullet)
            {
                Destroy(other.gameObject);
                takeDamage(bullet.damage);
            }
        }
    }
    private void takeDamage(int x)
    {
        if (isInvincible)
        {
            return;
        }

        animator.SetTrigger("OnHit");

        if (playerAudio != null)
            playerAudio.PlayHit();

        HitPoints -= x;
        if (HitPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        animator.SetTrigger("Dead");

        if (playerAudio != null)
            playerAudio.PlayDeath();

        Destroy(GetComponent<BoxCollider2D>());
        menuManager.GetComponent<MenuManager>().OpenResetMenu();
    }
    private void OnDeadAnimation()
    {
        Destroy(gameObject, 0f);
    }
}