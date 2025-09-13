using System;
using UnityEngine;

public class EnemyCollis : MonoBehaviour
{
    private Animator animator;

    [SerializeField] public float HitPoints = 4f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Me han pegao");
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
        //GetComponent<Collider>().enabled = false;
        transform.Rotate(0f, 0f, 180f * Time.deltaTime * 80, Space.Self);
    }
    private void OnDeadAnimation() 
    {
        Destroy(gameObject,1f);
    }
}
