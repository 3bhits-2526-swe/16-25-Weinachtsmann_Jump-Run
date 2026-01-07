using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rB;

    bool isTouching_ground = false;

    public float moveSpeed = 6f;
    public float acceleration = 20f;   // wie schnell Richtungswechsel
    public float jumpVelocity = 8f;

    void FixedUpdate()
    {
        Vector2 vel = rB.linearVelocity;

        float targetSpeed = 0f;

        if (Input.GetKey(KeyCode.D))
            targetSpeed = moveSpeed;
        else if (Input.GetKey(KeyCode.A))
            targetSpeed = -moveSpeed;

        // SANFTER RICHTUNGSWECHSEL
        vel.x = Mathf.MoveTowards(
            vel.x,
            targetSpeed,
            acceleration * Time.fixedDeltaTime
        );

        // SPRINGEN
        if (Input.GetKey(KeyCode.Space) && isTouching_ground)
        {
            vel.y = jumpVelocity;
            isTouching_ground = false;
        }

        rB.linearVelocity = vel;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isTouching_ground = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isTouching_ground = false;
    }
}
