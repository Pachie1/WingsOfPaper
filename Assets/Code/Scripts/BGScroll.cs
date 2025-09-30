using UnityEngine;
using static UnityEngine.UI.Image;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private float speed;

    private float spriteHeight;
    private float spriteWidth;
    private float originX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originX = transform.position.x;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bounds spriteBounds = sr.sprite.bounds;
        spriteWidth = spriteBounds.size.x;
    }

    // Update is called once per frame 
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.y < (originX - spriteWidth/2))
        {
            transform.Translate(spriteWidth, 0, 0);
        }
    }
}
