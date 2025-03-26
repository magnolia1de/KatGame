using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public PlayerController playerController;

    public void OnJumpButtonPressed()
    {
        if (playerController != null)
        {
            playerController.Jump();
        }
    }
}
