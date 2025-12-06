using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float bulletLife = 1f;
    [SerializeField] public float rotation = 0f;
    [SerializeField] public float speed;
    [SerializeField] public float damage = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.up.x;
        float y = timer * speed * transform.up.y;

        return new Vector2 (x+spawnPoint.x, y+spawnPoint.y);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
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
