using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int playerScore = 0;

    private Rigidbody2D rb;
    public TMP_Text pointsText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdatePointsUI();
    }

    public void Move(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (rb == null) return;

        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void GainPoint()
    {
        playerScore++;
        Debug.Log("Zdoby�e� punkt! Aktualny wynik: " + playerScore);
        UpdatePointsUI();
        // Mo�na tu doda� aktualizacj� UI
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = playerScore.ToString();
        }
    }

    public void LoseGame()
    {
        Debug.Log("Przegrales!");
        //jeśli to pierwsza gra gracza to tutorial niezaloczony, trzeba zagrać od początku
        //podliczenie punktów i usunięcie ich
    }

    public void LevelFinish()
    {
        Debug.Log("Gratulacje! Wygra?e?!");
        //jeśli to pierwsza gra gracza to tutorial zaliczony, przejście do poziomu 1
        //usunięcie wszystkich punktów jeśli to był tutorial, jeśli zwykła gra to podliczenie punktów i przejście do
        //kolejnego poziomu
        //jeśli to nie pierwsza gra to przejście do kolejnego poziomu
    }
}
