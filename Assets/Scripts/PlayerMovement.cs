using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform tankCannon;
    [SerializeField] SpriteRenderer tank;

    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float turnSpeed = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CannonRotation();
    }

    private void FixedUpdate()
    {
        TankMovement();

    }
    private void CannonRotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cannonDirection = mousePos - (Vector2)transform.position;
        tankCannon.right = cannonDirection.normalized;
    }

    private void TankMovement()
    {
        float speedX, speedY;
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector2 moveDirection = transform.right * speedY * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);
        float turnAmount = speedX * turnSpeed * Time.deltaTime;
        rb.rotation -= turnAmount;
    }

}
