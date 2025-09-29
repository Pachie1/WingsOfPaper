using System;
using UnityEngine;

public class EnemyCollis : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public int tag;
    [SerializeField] public float HitPoints = 4f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(UnityEditorInternal.InternalEditorUtility.tags[tag]))
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
