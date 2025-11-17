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
    [SerializeField] float speed = 6;

    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference attackAction;

    [Header("Player Shooting")]
    [SerializeField] private GameObject pfBullet;

    [Header("Bullet Attributes")]
    [SerializeField] private float firingRate = 0.2f;

    private GameObject spawnedBullet;
    public float bulletLife = 1f;
    private float timer = 0f;

    private PlayerAudio playerAudio;

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
        var moveInput = context.ReadValue<Vector2>();
        move = new Vector2(0f, 0f);
        move += moveInput * speed;
    }

    void Update()
    {
        rb.linearVelocity = move;
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
            Debug.LogError("Asigna la bullet");
        }
    }
}