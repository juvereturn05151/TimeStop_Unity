using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float turnSpeed = 5f;

    public float Noise { get; private set; }

    private const float noiseDivider = 100.0f;
    private CharacterController characterController;
    private Animator animator;
    private Vector2 input;
    private Vector3 horizontal;
    private Vector3 vertical;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        horizontal = input.x * transform.right;
        vertical = input.y * transform.forward;

        Noise = (horizontal.magnitude + vertical.magnitude) / noiseDivider;

        var movement = horizontal + vertical;

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();

        animator.SetFloat("SpeedX", input.x);
        animator.SetFloat("SpeedY", input.y);
    }
}
