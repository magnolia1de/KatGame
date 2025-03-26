using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int playerLives = 3;
    public int playerScore = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Brak komponentu Rigidbody2D na obiekcie Player!");
        }
    }

    public void Move(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (rb == null) return;

        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f) // Sprawdza, czy gracz jest na ziemi
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void GainPoint()
    {
        playerScore++;
        Debug.Log("Zdoby�e� punkt! Aktualny wynik: " + playerScore);
        // Mo�na tu doda� aktualizacj� UI
    }

    public void LoseLife()
    {
        playerLives--;
        Debug.Log("Straci�e� �ycie! Pozosta�e �ycia: " + playerLives);

        if (playerLives <= 0)
        {
            Debug.Log("Gra sko�czona!");
            // Mo�na tu doda� kod do ko�ca gry (np. restart poziomu)
        }
    }
}
