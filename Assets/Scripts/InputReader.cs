using UnityEditor.Timeline.Actions;
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
<<<<<<< Updated upstream:Assets/Scripts/InputReader.cs
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
=======
    [SerializeField] float speed = 4;
>>>>>>> Stashed changes:Assets/Code/Scripts/InputReader.cs

    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference attackAction;

    [Header("Player Shooting")]
    [SerializeField] private GameObject pfBullet;


    [Header("Bullet Attributes")]
    [SerializeField] private float firingRate = 0.2f;

    private GameObject spawnedBullet;
    public float bulletLife = 1f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
<<<<<<< Updated upstream:Assets/Scripts/InputReader.cs
        speed = 10; 
        rotationSpeed= 720f;
=======
>>>>>>> Stashed changes:Assets/Code/Scripts/InputReader.cs
        animator = GetComponent<Animator>();

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;
    }

    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        var moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
        move = new Vector2(0f,0f);
        move += moveInput * speed;

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", move.x);
            animator.SetFloat("YInput", move.y);
        }
    }

    // Update is called once per frame
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

    private void FixedUpdate()
    {
        //RotateInDirectionOfInput(); 
    }

    private void RotateInDirectionOfInput() 
    {
        if (move != Vector2.zero) 
        { 
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward,move);
            Quaternion rotation= Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    
    }

    private void Fire()
    {
        if (pfBullet)
        {
            GameObject instance = Instantiate(pfBullet, FirePoint.transform.position, FirePoint.transform.rotation);
            //Destroy(instance, bulletLife);
        }
        else 
        {
            Debug.LogError("Asignaaaa la bullet");
        }
    }
}
