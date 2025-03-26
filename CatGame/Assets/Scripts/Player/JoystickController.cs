using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public VariableJoystick joystick;
    public PlayerController playerController;

    private void Update()
    {
        if (playerController != null)
        {
            playerController.Move(joystick.Horizontal);
        }
    }
}
