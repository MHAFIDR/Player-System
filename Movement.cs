using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Movespeed;
    public float turnSpeed = 15f;
    public LayerMask groundLayer;
    private bool isGrounded;
    private Transform cameraTransform;
    private CharacterController character;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 targetDirection = cameraTransform.forward;
        targetDirection.y = 0;
        targetDirection.Normalize();

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        Move();
        Fall();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (cameraTransform.forward * vertical) + (cameraTransform.right * horizontal);
        moveDirection.y = 0;
        moveDirection.Normalize();

        character.Move(moveDirection * Movespeed * Time.deltaTime);
    }

    public void Fall()
    {
        isGrounded = Physics.CheckSphere(transform.position,0.1f,groundLayer);
        if ( !isGrounded)
        {
            float height = transform.position.y;
            height -= 20;
            Vector3 fallMovement = new Vector3(0,height,0);
            character.Move(fallMovement * Time.deltaTime);
        }
    }
}
