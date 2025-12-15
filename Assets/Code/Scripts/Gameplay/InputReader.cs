using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private Vector2 move = new Vector2();

    private Animator animator;

    [Header("Player component references")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject FirePoint;

    [Header("Player Settings")]
    [SerializeField] private float speed = 6;
    private float defaultSpeed;

    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference attackAction;

    [Header("Player Shooting")]
    [SerializeField] private GameObject pfBullet;

    [Header("Bullet Attributes")]
    [SerializeField] private float firingRate = 0.2f;
    private float defaultFiringRate;

    private GameObject spawnedBullet;
    public float bulletLife = 1f;
    private float timer = 0f;

    private PlayerAudio playerAudio;

    public void SetCurrentSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetDefaultSpeed()
    {
        return defaultSpeed;
    }
    public void SetCurrentFiringRate(float newRate)
    {
        firingRate = newRate;
    }
    public float GetDefaultFiringRate()
    {
        return defaultFiringRate;
    }
    private void Awake()
    {
        defaultSpeed = speed;
        defaultFiringRate = firingRate;
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<PlayerAudio>();

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;
    }
    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Update()
    {
        rb.linearVelocity = move * speed;
        timer += Time.deltaTime;

        if (attackAction.action.IsPressed())
        {
            if (timer >= firingRate)
            {
                Fire();
                timer = 0f;
            }
        }
    }
    private void Fire()
    {
        if (pfBullet)
        {
            GameObject instance = Instantiate(pfBullet, FirePoint.transform.position, FirePoint.transform.rotation);

            if (playerAudio != null)
                playerAudio.PlayShoot();
        }
        else
        {
            Debug.LogError("Assign the bullet prefab.");
        }
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
            rb.linearVelocity = new Vector2(0f, 0f);
            enabled = false;
        }
    }
}