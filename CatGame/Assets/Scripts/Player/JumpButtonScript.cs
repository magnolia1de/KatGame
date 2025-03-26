using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    public float jumpForce = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        
        if (rb == null)
        {
            Debug.LogError("Missing Rigidbody2D component! Add it to the object.");
        }
    }

    public void Jump()
    {
        Debug.Log("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
