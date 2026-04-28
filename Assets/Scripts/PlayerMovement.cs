using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Player Components")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioSource footstepAudioSource;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 2.4f;
    [SerializeField] private float runSpeed = 3.8f;
    [SerializeField] private float gravity = -20f;

    [Header("Camera Settings")]
    [SerializeField] private float lookSpeed = 0.03f;
    [SerializeField] private float lookXLimit = 80f;

    [Header("Player State")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canLook = true;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Vector3 moveDirection;
    private float verticalVelocity;
    private float rotationX;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        footstepAudioSource = GetComponent<AudioSource>();

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        movePlayer();
        moveCamera();
        handleFootsteps();
    }

    private void movePlayer()
    {
        if (!canMove)
        {
            return;
        }

        float currentSpeed = walkSpeed;

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = runSpeed;
        }

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        moveDirection = (forward * moveInput.y) + (right * moveInput.x);

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        moveDirection = moveDirection * currentSpeed;

        if (characterController.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void moveCamera()
    {
        if (!canLook)
        {
            return;
        }

        rotationX -= lookInput.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed);

        lookInput = Vector2.zero;
    }

    private void handleFootsteps()
    {
        if (footstepAudioSource == null)
        {
            return;
        }

        bool isMoving = characterController.isGrounded && moveInput.magnitude > 0.1f;

        if (isMoving)
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("E button pressed");
            InteractionManager.Instance.TryInteract();
        }
    }
}