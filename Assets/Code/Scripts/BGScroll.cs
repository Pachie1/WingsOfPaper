using UnityEngine;
using static UnityEngine.UI.Image;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private float speed;

    private float spriteHeight;
    private float spriteWidth;
    private float originX;

    void Start()
    {
        originX = transform.position.x;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bounds spriteBounds = sr.sprite.bounds;
        spriteWidth = spriteBounds.size.x;
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.y < (originX - spriteWidth / 2))
        {
            transform.Translate(spriteWidth, 0, 0);
        }
    }


    //Pause
    private void Awake() 
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        if (newGameState == GameState.Gameplay)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }
}