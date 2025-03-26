using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;

    public void Jump()
    {
        Debug.Log("Jump");

        if (rb == null)
        {
            Debug.LogError("Missing Rigidbody2D component! Add it to the object.");
            return;
        }

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Jump");

    }

}
