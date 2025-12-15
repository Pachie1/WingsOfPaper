using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHealth;
    public Sprite fullHeart;
    public Image[] hearts;

    public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        health = player.HitPoints;
        maxHealth = player.maxHitPoints;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) 
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHealth;
            }



            if (i < maxHealth) 
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
