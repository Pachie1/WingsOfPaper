using System;
using UnityEngine;

public class EnemyCollis : MonoBehaviour
{
    [SerializeField] public float HitPoints = 4f; 
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
        HitPoints -= x;

        if (HitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
