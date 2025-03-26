using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;

    public void Jump()
    {
        Debug.Log("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
