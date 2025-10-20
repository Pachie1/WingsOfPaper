using UnityEngine;

public class EnemyCollis : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public string Enemytag;
    [SerializeField] public float HitPoints = 4f;


    private void Start()
    {
        animator = GetComponent<Animator>();
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

    private void takeDamage(float x)
    {
        animator.SetTrigger("OnHit");
        HitPoints -= x;
        if (HitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
        Destroy(GetComponent<BoxCollider2D>());
    }
    private void OnDeadAnimation() 
    {
        Destroy(gameObject,0f);
    }
}
