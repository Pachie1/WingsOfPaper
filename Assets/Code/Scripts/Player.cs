using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public string Enemytag;
    [SerializeField] public int HitPoints;
    [SerializeField] public int maxHitPoints;

    private PlayerAudio playerAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<PlayerAudio>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Enemytag))
        {
            Destroy(other.gameObject);
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet)
            {
                takeDamage(bullet.damage);
            }
        }
    }

    private void takeDamage(int x)
    {
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
    }

    private void OnDeadAnimation()
    {
        Destroy(gameObject, 0f);
    }
}
