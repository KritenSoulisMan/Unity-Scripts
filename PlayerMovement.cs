using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool isJumping = false;

    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            anim.SetFloat("X", horizontalInput);
            anim.SetFloat("Y", verticalInput);

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                anim.SetTrigger("Jump");

                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }
        else
        {
            isJumping = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
