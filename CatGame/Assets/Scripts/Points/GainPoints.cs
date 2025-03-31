using UnityEngine;

public class GainPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.GainPoint();
            Destroy(gameObject);
        }
    }
}
